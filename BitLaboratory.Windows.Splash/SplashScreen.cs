/*
*
* Copyright (C) 2004 - BitLaboratory
* All rights reserved.
*
* Redistribution and use in source and binary forms, with or without modification, 
* are permitted provided that the following conditions are met:
*
* 1. Redistributions of source code must retain the above copyright notice,
*    this list of conditions and the following disclaimer.
* 2. Redistributions in binary form must reproduce the above copyright notice,
*    this list of conditions and the following disclaimer in the documentation
*    and/or other materials provided with the distribution.
* 3. The name of the author may not be used to endorse or promote products
*    derived from this software without specific prior written permission. 
*
* THIS SOFTWARE IS PROVIDED BY THE AUTHOR ``AS IS'' AND ANY EXPRESS OR IMPLIED 
* WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF 
* MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT 
* SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, 
* EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT 
* OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
* INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
* CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING 
* IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
* OF SUCH DAMAGE.
*
* You can find the latest version of this library at https://github.com/mbolaric/net-win-forms-splash
*
*/

using System;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using BitLaboratory.Win32Api;
using BitLaboratory.Win32Api.Drawing;
using BitLaboratory.Win32Api.Windows;
using System.Security;

namespace BitLaboratory.Windows.Splash
{
	/// <summary>
	/// Represents a method that will handle custom painting over splash screen.
	/// </summary>
	/// <param name="surface">Provides surface for custom painting</param>
	public delegate void SplashScreenCustomizeCallback(SplashScreenSurface surface);
	
	/// <summary>
	/// Represents a splash object
	/// </summary>
	/// <example> How-to use SplashScreen class
	/// <code>
	/// using System;
	///	using System.Diagnostics;
	///	using System.Drawing;
	///	using BitLaboratory.Windows.Splash;
	///
	///	namespace SplashTest
	///	{
	///		public class Application
	///		{
	///			public Application()
	///			{
	///			}
	///
	///			private static void SplashScreenCustomizer(SplashScreenSurface surface)
	///			{
	///				FileVersionInfo info = FileVersionInfo.GetVersionInfo(typeof(Application).Module.FullyQualifiedName);
	///				string textVersion = string.Format("Version {0}.{1} (Build {2})", info.ProductMajorPart, info.ProductMinorPart, info.ProductBuildPart);
	///				string textNET = string.Concat(".NET Framework Version ", Environment.Version);
	///				Graphics graphics = surface.Graphics;
	///				Font textFont = new Font("Tahoma", 8);
	///
	///				graphics.DrawString(textVersion, textFont, Brushes.Black, 60, 220);
	///				graphics.DrawString(textNET, textFont, Brushes.Black, 60, 236);
	///			
	///				textFont.Dispose();
	///			}	
	///
	///			[STAThread]
	///			static void Main() 
	///			{
	///				SplashScreen screen;
	///				MainWindow window = null;
	///
	///				try
	///				{
	///					screen = SplashScreen.Current;
	///					screen.Image = new Bitmap(typeof(Application), "Resources.Splash.gif");
	///					screen.Customizer = new SplashScreenCustomizeCallback(Application.SplashScreenCustomizer);
	///					screen.ShowShadow = true;
	///					screen.MinimumDuration = 4000;
	///					screen.Show();
	///
	///					window = new MainWindow();
	///					System.Windows.Forms.Application.Run(window);
	///				}
	///				catch( Exception ex )
	///				{
	///					if ( null != window )
	///						SplashScreen.Current.Hide(window);
	///					System.Windows.Forms.MessageBox.Show( ex.Message );
	///				}
	///			}
	///		}
	///	}
	///	</code>
	///	To hide splash use this code.
	///	<code>
	///		SplashScreen.Current.Hide(window);
	///	</code>
	/// </example>
	/// <example> 
	///  How-to use SplashScreen class with additional data
	/// <code>
	/// using System;
	///	using System.Diagnostics;
	///	using System.Drawing;
	///	using BitLaboratory.Windows.Splash;
	///
	///	namespace SplashTest
	///	{
	/// 	public class Application
	///		{
	/// 		public Application()
	///			{
	///			}
	/// 
	/// 		private static void SplashScreenCustomizer(SplashScreenSurface surface)
	///			{
	/// 			FileVersionInfo info = FileVersionInfo.GetVersionInfo(typeof(Application).Module.FullyQualifiedName);
	/// 			string textVersion = string.Format("Version {0}.{1} (Build {2})", info.ProductMajorPart, info.ProductMinorPart, info.ProductBuildPart);
	/// 			string textNET = string.Concat(".NET Framework Version ", Environment.Version);
	/// 			Graphics graphics = surface.Graphics;
	/// 			Font textFont = new Font("Tahoma", 8);
	/// 			
	/// 			Rectangle rectangle = surface.Bounds;
	/// 			int startX = 60;
	/// 
	/// 			graphics.DrawString(textVersion, textFont, Brushes.Black, startX, 166);
	/// 			graphics.DrawString(textNET, textFont, Brushes.Black, startX, 182);
	/// 
	/// 			RedrawCustomData data = surface.RedrawData;
	/// 			if( data != RedrawCustomData.Empty )
	/// 				graphics.DrawString((String)data.RedrawData, textFont, Brushes.Red, startX, 198);
	/// 
	/// 			Bitmap image = new Bitmap(typeof(Application), "Resources.AppIcon.gif");
	/// 			Rectangle destRec = new Rectangle( startX, 217, image.Width, image.Height );
	/// 
	/// 			graphics.DrawImage( image, destRec, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel );
	/// 			destRec = new Rectangle( startX + image.Width + 7, 217, image.Width, image.Height );
	/// 			graphics.DrawImage( image, destRec, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel );
	/// 			destRec = new Rectangle( startX + image.Width * 2 + 7 * 2, 217, image.Width, image.Height );
	/// 			graphics.DrawImage( image, destRec, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel );
	/// 
	/// 			textFont.Dispose();
	///			}	
	/// 
	/// 		[STAThread]
	/// 		static void Main() 
	///			{
	/// 			SplashScreen screen;
	/// 			MainWindow window = null;
	/// 
	/// 			try
	///				{
	/// 				screen = SplashScreen.Current;
	/// 				screen.Image = new Bitmap(typeof(Application), "Resources.Splash.gif");
	/// 				screen.RedrawData = new RedrawCustomData( "Initializing ..." );
	/// 				screen.Customizer = new SplashScreenCustomizeCallback(Application.SplashScreenCustomizer);
	/// 				screen.ShowShadow = true;
	/// 				screen.MinimumDuration = 4000;
	/// 
	/// 				screen.Show();
	/// 
	/// 				window = new MainWindow();
	/// 				System.Windows.Forms.Application.Run(window);
	///				}
	/// 			catch( Exception ex )
	///				{
	/// 				if ( null != window )
	/// 					SplashScreen.Current.Hide(window);
	/// 				System.Windows.Forms.MessageBox.Show( ex.Message );
	///				}
	///			}
	///		}
	/// }
	/// </code>
	/// Invoke call of custom callback method.
	/// <code>
	///		SplashScreen.Current.InvokeRedraw(new RedrawCustomData("Loading ..."));
	/// </code>
	///	To hide splash use this code.
	///	<code>
	///		SplashScreen.Current.Hide(window);
	///	</code>
	/// </example>
	/// <remarks>
	/// The SplashScreen class represents a component used to display an manage splash screen.
	/// </remarks>
	[ToolboxItem(false)]
	public sealed class SplashScreen : MarshalByRefObject
	{
		private SplashScreenCustomizeCallback _customizer;
		private int _height;
		private IntPtr _hwnd = IntPtr.Zero;
		private Image _image;
		private int _minimumDuration;
		private bool _minimumDurationComplete;
		private bool _showShadow;
		private int _timer;
		private Color _transparencyKey;
		private bool _waitingForTimer;
		private int _width;
		private IWin32Window _windowToActivate;
		private static SplashScreen current;
		private static WNDPROC splashWindowProcedure = null;
		private const string ThreadName = "FwSplashThread";
		private const string WindowClassName = "FwSplashWindow";
 
		private IntPtr _handleToActivate;
		private RedrawCustomData _redrawCustomData = RedrawCustomData.Empty;

		private SplashScreen() : base()
		{
			_transparencyKey = Color.Empty;
			_handleToActivate = IntPtr.Zero;
		}

		private void ResetData()
		{
			_transparencyKey = Color.Empty;
			_handleToActivate = IntPtr.Zero;

			_hwnd = IntPtr.Zero;
			_timer = 0;
			_waitingForTimer = false;
			_windowToActivate = null;
			_handleToActivate = IntPtr.Zero;
		}

        [SecuritySafeCritical]
        private bool CreateNativeWindow()
		{
			bool isCreated = false;
			uint windowStyle;
			uint windowStyleEx;
			Screen screen;
			Rectangle rectangle;

			windowStyle = (uint)WindowStyles.WS_POPUP | (uint)WindowStyles.WS_VISIBLE;
			windowStyleEx = (uint)WindowStylesEx.WS_EX_TOPMOST | (uint)WindowStylesEx.WS_EX_TOOLWINDOW;

			if( !this._transparencyKey.IsEmpty && this.IsLayeringSupported() )
			{
				windowStyleEx = (windowStyleEx | (uint)WindowStylesEx.WS_EX_LAYERED ); // 524288
			}
			
			screen = Screen.FromPoint(Control.MousePosition);
			rectangle = screen.WorkingArea;

			int posX = Math.Max(rectangle.X, (rectangle.X + ((rectangle.Width - this._width) / 2)));
			int posY = Math.Max(rectangle.Y, (rectangle.Y + ((rectangle.Height - this._height) / 2)));

            this._hwnd = APIWindow.CreateWindowEx(windowStyleEx, WindowClassName, "", (uint)windowStyle, posX, posY, this._width, this._height, IntPtr.Zero, IntPtr.Zero, APIDynamicLinkLibrary.GetModuleHandle(null), IntPtr.Zero);
			 
			if( this._hwnd != IntPtr.Zero )
			{
				APIWindow.ShowWindow(this._hwnd, 1);
				APIWindow.UpdateWindow(this._hwnd);
				isCreated = true;
			}
			else
			{
				System.Console.WriteLine("Cannot create window. {0}", APIError.FormatMessage(APIError.GetLastError()));
			}

			return( isCreated );
		}

		/// <summary>
		/// Hide splash screen.
		/// </summary>
		/// <param name="windowToActivate">Window to activate after hide splash screen</param>
		/// <remarks>
		/// Splash screen will hide after minimum duration is complete.
		/// </remarks>
		[Description("Hide splash screen.")]
        [SecuritySafeCritical]
        public void Hide(IWin32Window windowToActivate)
		{
			this._windowToActivate = windowToActivate;
			_handleToActivate = this._windowToActivate != null ? this._windowToActivate.Handle : IntPtr.Zero;

			if( this._minimumDuration > 0 )
			{
				this._waitingForTimer = true;
				if( !this._minimumDurationComplete )
				{
					return; 
				}
			}

			if( this._hwnd != IntPtr.Zero )
			{
				APIMessage.PostMessage(this._hwnd, (int)WindowMessages.WM_CLOSE, (uint)IntPtr.Zero, (uint)IntPtr.Zero);
			}
		}

		private bool IsDropShadowSupported()
		{
			return( !(Environment.OSVersion.Version.CompareTo(new Version(5, 1, 0, 0)) < 0) ); 
		}

		private bool IsLayeringSupported()
		{
			return( !(Environment.OSVersion.Version.CompareTo(new Version(5, 0, 0, 0)) < 0) );
		}

        [SecuritySafeCritical]
        private bool RegisterWindowClass()
		{
			bool registerSuccess;
			WNDCLASS wndClass;

			SplashScreen.splashWindowProcedure = new WNDPROC( SplashWindowProcedure );

			registerSuccess = false;
			wndClass = new WNDCLASS();

			wndClass.style = (int)((int)ClassStylesFlags.CS_VREDRAW | (int)ClassStylesFlags.CS_HREDRAW);
			wndClass.hInstance = APIDynamicLinkLibrary.GetModuleHandle( null );//(IntPtr) 0;
			wndClass.hIcon = (IntPtr) 0;
			wndClass.hCursor = (IntPtr) 0;
			wndClass.hbrBackground = ((IntPtr) SystemColorsIndex.COLOR_WINDOWFRAME);
			wndClass.lpszMenuName = "";
			wndClass.cbClsExtra = 0;
			wndClass.cbWndExtra = 0;
			wndClass.lpfnWndProc = SplashScreen.splashWindowProcedure;
            wndClass.lpszClassName = WindowClassName;

			
			if( this._showShadow && this.IsDropShadowSupported() )
			{
				wndClass.style = (wndClass.style | (int)WindowClassStyles.CS_DROPSHADOW );
			}
			else
			{
				wndClass.style &=  ~((int)WindowClassStyles.CS_DROPSHADOW );
			}

			if( APIWindow.RegisterClass( ref wndClass ) != IntPtr.Zero )
			{
				registerSuccess = true;
 			}

			return( registerSuccess );
		}

		/// <summary>
		/// Gets a Handle of Splash Screen Window.
		/// </summary>
		[Description("Gets a Handle of Splash Screen Window")]
		public IntPtr Handle
		{
			get{ return _hwnd; }
		}

		/// <summary>
		/// Show splash screen.
		/// </summary>
		[Description("Show splash screen.")]
		public void Show()
		{
			Thread thread;

			if( this._hwnd == IntPtr.Zero )
			{
				this.ResetData();
				if( this._image == null )
				{
					throw new InvalidOperationException("Image must be set first");
				}

				thread = new Thread(new ThreadStart(SplashScreen.SplashThreadProcedure));

				thread.Name = ThreadName;
				thread.TrySetApartmentState(ApartmentState.STA);
				thread.Start();
				thread.IsBackground = true;
 
			}
		}

        [SecuritySafeCritical]
        private static void SplashThreadProcedure()
		{
			bool isOK = true;
			MSG message;

			if( SplashScreen.splashWindowProcedure == null )
			{
				isOK = SplashScreen.current.RegisterWindowClass();
 			}

			if( isOK )
			{
				isOK = SplashScreen.current.CreateNativeWindow();
			}

			if( isOK )
			{
				message = new MSG();

				while( APIMessage.GetMessage( ref message, IntPtr.Zero, 0, 0) )
				{
					APIMessage.TranslateMessage( ref message );
					APIMessage.DispatchMessage( ref message );
 				}

				SplashScreen.current._hwnd = IntPtr.Zero;

				if( SplashScreen.current._windowToActivate != null )
				{
					if( SplashScreen.current._handleToActivate != IntPtr.Zero )
					{
						SplashScreen.Current._windowToActivate = null;
						APIWindow.SetForegroundWindow(APIWindow.GetLastActivePopup(SplashScreen.current._handleToActivate));
						APIPainting.RedrawWindow(SplashScreen.current._handleToActivate, IntPtr.Zero, IntPtr.Zero, (uint)0x85); 
						SplashScreen.current._handleToActivate = IntPtr.Zero;
					}
 				}
 			}
		}

        [SecuritySafeCritical]
        private int SplashWindowProcedure(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam)
		{
			PAINTSTRUCT paintStruct;
			IntPtr timerPtr;
			Graphics graphics;

			if( msg <= (int)WindowMessages.WM_PAINT )
			{
				switch( msg  )
				{
					case (int)WindowMessages.WM_CREATE:
					{
						if( !this._transparencyKey.IsEmpty && this.IsLayeringSupported() )
						{
							APIWindow.SetLayeredWindowAttributes(hwnd, (ulong)ColorTranslator.ToWin32(this._transparencyKey), (byte)0, LayeredWindowAttributesFlags.LWA_COLORKEY);
						}

						if( this._minimumDuration <= 0 )
						{
							return( APIWindow.DefWindowProc(hwnd, msg, wParam, lParam) ); 
						}

						this._timer = APITimer.SetTimer(hwnd, 1, this._minimumDuration, (TIMERPROC)null);
						return( APIWindow.DefWindowProc(hwnd, msg, wParam, lParam) ); 
					}
					case (int)WindowMessages.WM_DESTROY:
					{
						APIMessage.PostQuitMessage(0);
						return( APIWindow.DefWindowProc(hwnd, msg, wParam, lParam) ); 
					}
				}

				if( msg == (int)WindowMessages.WM_PAINT )
				{
					paintStruct = new PAINTSTRUCT();
					timerPtr = APIPainting.BeginPaint(hwnd, ref paintStruct );

					if( timerPtr != IntPtr.Zero )
					{
						graphics = Graphics.FromHdcInternal(timerPtr);
						graphics.DrawImage(this._image, 0, 0, this._width, this._height);
						
						OnScreenCustomize( graphics );

						graphics.Dispose();
					}

					APIPainting.EndPaint(hwnd, ref paintStruct );
					return( 0 ); 
				}

				return( APIWindow.DefWindowProc(hwnd, msg, wParam, lParam) ); 
			}

			if( msg == (int)WindowMessages.WM_ERASEBKGND )
			{
				return( 1 ); 
			}

			if( msg == (int)WindowMessages.WM_TIMER )
			{
				APITimer.KillTimer(hwnd, this._timer);
				this._timer = 0;
				this._minimumDurationComplete = true;

				if( this._waitingForTimer )
				{
					APIMessage.PostMessage(hwnd, (int)WindowMessages.WM_CLOSE, (uint)IntPtr.Zero, (uint)IntPtr.Zero);
				}

				return( 0 ); 
			}

			return( APIWindow.DefWindowProc(hwnd, msg, wParam, lParam) ); 
		}

		private void OnScreenCustomize(Graphics graphics)
		{
			lock( current )
			{
				if( this._customizer != null )
				{
					this._customizer( new SplashScreenSurface(graphics, new Rectangle(0, 0, this._width, this._height), this._redrawCustomData) );
				}
			}
		}

		/// <summary>
		/// Current instance of SplashScreen class.
		/// </summary>
		[Description("Current instance of SplashScreen class.")]
		public static SplashScreen Current 
		{ 
			get
			{
				if( SplashScreen.current == null )
				{
					SplashScreen.current = new SplashScreen();
 				}
				return( SplashScreen.current );
			} 
		}

		/// <summary>
		/// Gets or sets delegate for custom painting over splash screen.
		/// </summary>
		[Description("Gets or sets delegate for custom painting over splash screen.")]
		public SplashScreenCustomizeCallback Customizer 
		{ 
			get{ return( this._customizer ); } 
			set
			{
				if( this._hwnd != IntPtr.Zero )
				{
					throw new InvalidOperationException();
 				}
				this._customizer = value;
			} 
		}

		/// <summary>
		/// Gets or sets the image that the <see cref="BitLaboratory.Windows.Splash.SplashScreen">SplashScreen</see> displays
		/// </summary>
		[Description("Gets or sets the image that the 'SplashScreen' displays.")]
		public Image Image 
		{ 
			get{ return( this._image ); } 
			set
			{
				if( this._hwnd != IntPtr.Zero )
				{
					throw new InvalidOperationException();
				}

				this._image = value;

				if( this._image != null )
				{
					this._width = this._image.Width;
					this._height = this._image.Height;
				}
			} 
		}

		/// <summary>
		/// Gets or sets the minimal duration in miliseconds.
		/// </summary>
		[Description("Gets or sets the minimal duration in miliseconds.")]
		public int MinimumDuration  
		{ 
			get{ return( this._minimumDuration ); } 
			set
			{
				if( value < 0 )
				{
					throw new ArgumentOutOfRangeException();
				}

				if( this._hwnd != IntPtr.Zero )
				{
					throw new InvalidOperationException();
				}

				this._minimumDuration = value;
			} 
		}

		/// <summary>
		/// Gets or sets the property the indicate when shadow is displayed.
		/// </summary>
		[Description("Display shadow")]
        public bool ShowShadow 
		{ 
			get{ return( this._showShadow ); }
            [SecuritySafeCritical]
            set
			{
				if( this._hwnd != IntPtr.Zero )
				{
					throw new InvalidOperationException();
 				}

				this._showShadow = value;

				if( SplashScreen.splashWindowProcedure != null )
				{
					APIWindow.UnregisterClass( WindowClassName, APIDynamicLinkLibrary.GetModuleHandle( null ));
					this.RegisterWindowClass();
				}
			} 
		}
		
		/// <summary>
		/// This method invoke painting of splash bitmap.
		/// </summary>
		[Description("This method invoke painting of splash bitmap.")]
        [SecuritySafeCritical]
        public void Refresh()
		{
			if( this._hwnd != IntPtr.Zero)
			{
				APIPainting.RedrawWindow( this._hwnd, IntPtr.Zero, IntPtr.Zero, (uint)0x85  );
			}
		}

		/// <summary>
		/// Invoke a call customizer with custom redraw data.
		/// </summary>
		/// <param name="redrawData">Additional data for drawing.</param>
		[Description("Invoke a call customizer with custom redraw data")]
		public void InvokeRedraw( RedrawCustomData redrawData )
		{
			this._redrawCustomData = redrawData;
			this.Refresh();
		}

		/// <summary>
		/// Gets or sets additional data for drawing.
		/// </summary>
		[Description("Gets or sets additional data for drawing")]
		public RedrawCustomData RedrawData
		{
			get{ return _redrawCustomData; }
			set
			{ 
				if( _redrawCustomData != value )
				{
					this.InvokeRedraw(value);
				}
			}
		}

		/// <summary>
		/// Gets or sets the color that will represent transparent areas of the splash
		/// </summary>
		[Description("Gets or sets the color that will represent transparent areas of the splash")]
		public Color TransparencyKey 
		{ 
			get{ return( this._transparencyKey ); } 
			set
			{
				if( this._hwnd != IntPtr.Zero )
				{
					throw new InvalidOperationException();
				}

				this._transparencyKey = value;
			} 
		}
	}
}
