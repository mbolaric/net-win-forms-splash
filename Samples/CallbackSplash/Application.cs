using System;
using System.Diagnostics;
using System.Drawing;
using BitLaboratory.Windows.Splash;

namespace BitLaboratory.CallbackSplash
{
	/// <summary>
	/// 
	/// </summary>
	public class Application
	{
		public Application()
		{
		}

		private static void SplashScreenCustomizer(SplashScreenSurface surface)
		{
			FileVersionInfo info = FileVersionInfo.GetVersionInfo(typeof(Application).Module.FullyQualifiedName);
			string textVersion = string.Format("Version {0}.{1} (Build {2})", info.ProductMajorPart, info.ProductMinorPart, info.ProductBuildPart);
			string textNET = string.Concat(".NET Framework Version ", Environment.Version);
			Graphics graphics = surface.Graphics;
			Font textFont = new Font("Tahoma", 8);
			
			Rectangle rectangle = surface.Bounds;
			int startX = 60;

			graphics.DrawString(textVersion, textFont, Brushes.Black, startX, 166);
			graphics.DrawString(textNET, textFont, Brushes.Black, startX, 182);

			RedrawCustomData data = surface.RedrawData;
			if( data != RedrawCustomData.Empty )
				graphics.DrawString((String)data.RedrawData, textFont, Brushes.Red, startX, 198);

			Bitmap image = new Bitmap(typeof(Application), "Resources.AppIcon.gif");
			Rectangle destRec = new Rectangle( startX, 217, image.Width, image.Height );

			graphics.DrawImage( image, destRec, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel );
			destRec = new Rectangle( startX + image.Width + 7, 217, image.Width, image.Height );
			graphics.DrawImage( image, destRec, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel );
			destRec = new Rectangle( startX + image.Width * 2 + 7 * 2, 217, image.Width, image.Height );
			graphics.DrawImage( image, destRec, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel );

			textFont.Dispose();
 		}	

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			SplashScreen screen;
			MainWindow window = null;

			try
			{
				screen = SplashScreen.Current;
				screen.Image = new Bitmap(typeof(Application), "Resources.Splash.gif");
				screen.RedrawData = new RedrawCustomData( "Initializing ..." );
				screen.Customizer = new SplashScreenCustomizeCallback(Application.SplashScreenCustomizer);
				screen.ShowShadow = true;
				screen.MinimumDuration = 4000;

				screen.Show();

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

