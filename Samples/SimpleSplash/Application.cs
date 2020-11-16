using System;
using System.Diagnostics;
using System.Drawing;
using BitLaboratory.Windows.Splash;

namespace BitLaboratory.SimpleSplash
{
	/// <summary>
	/// 
	/// </summary>
	public class Application
	{
		public Application()
		{
		}

		public static void ShowSplash()
		{
			SplashScreen screen = SplashScreen.Current;

			screen.Image = new Bitmap(typeof(Application), "Resources.Splash.gif");
			screen.ShowShadow = true;
			screen.MinimumDuration = 4000;
			screen.Show();
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			MainWindow window = null;

			try
			{
				ShowSplash();

				window = new MainWindow();
				System.Windows.Forms.Application.Run(window);
			}
			catch( Exception ex )
			{
				if ( null != window )
					SplashScreen.Current.Hide(window);
				System.Windows.Forms.MessageBox.Show( ex.Message );
			}
		}

	}
}
