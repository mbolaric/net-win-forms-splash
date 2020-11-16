using BitLaboratory.Windows.Splash;

namespace BitLaboratory.CallbackSplash
{
	/// <summary>
	/// 
	/// </summary>
	public class MainWindow : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PropertyGrid _splashPropertyGrid;
		private System.Windows.Forms.Panel _holder;
		private System.Windows.Forms.Button _show;
		private System.Windows.Forms.PictureBox pictureBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainWindow()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this._splashPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this._holder = new System.Windows.Forms.Panel();
            this._show = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this._holder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // _splashPropertyGrid
            // 
            this._splashPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splashPropertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
            this._splashPropertyGrid.Location = new System.Drawing.Point(0, 57);
            this._splashPropertyGrid.Name = "_splashPropertyGrid";
            this._splashPropertyGrid.Size = new System.Drawing.Size(415, 286);
            this._splashPropertyGrid.TabIndex = 2;
            // 
            // _holder
            // 
            this._holder.Controls.Add(this._show);
            this._holder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._holder.Location = new System.Drawing.Point(0, 343);
            this._holder.Name = "_holder";
            this._holder.Size = new System.Drawing.Size(415, 59);
            this._holder.TabIndex = 3;
            // 
            // _show
            // 
            this._show.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._show.Location = new System.Drawing.Point(330, 21);
            this._show.Name = "_show";
            this._show.Size = new System.Drawing.Size(75, 23);
            this._show.TabIndex = 0;
            this._show.Text = "Show";
            this._show.Click += new System.EventHandler(this.OnShowClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(415, 57);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(415, 402);
            this.Controls.Add(this._splashPropertyGrid);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this._holder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Callback Splash";
            this.Load += new System.EventHandler(this.OnLoad);
            this._holder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void OnLoad(object sender, System.EventArgs e)
		{
			SplashScreen.Current.Hide(this);
            this._splashPropertyGrid.SelectedObject = SplashScreen.Current;
            SimulateLoading();
		}

		private void OnShowClick(object sender, System.EventArgs e)
		{
			SplashScreen.Current.Show();
			SimulateLoading();
            System.Threading.Thread.Sleep(2000);
            SplashScreen.Current.Hide(this);
		}

		private void SimulateLoading()
		{
			SplashScreen.Current.InvokeRedraw(new RedrawCustomData("Loading ..."));
			for (int i = 0; i < 6; i++ )
			{
				SplashScreen.Current.InvokeRedraw(new RedrawCustomData("Loading " + i.ToString()));
				System.Threading.Thread.Sleep(1000);
			}
			SplashScreen.Current.InvokeRedraw(new RedrawCustomData("Loaded"));
		}

	}
}
