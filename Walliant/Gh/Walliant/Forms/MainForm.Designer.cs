namespace Gh.Walliant.Forms
{
	// Token: 0x0200002C RID: 44
	internal partial class MainForm : global::Gh.Common.Forms.HiddenForm
	{
		// Token: 0x06000096 RID: 150 RVA: 0x00003804 File Offset: 0x00001A04
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00003824 File Offset: 0x00001A24
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Gh.Walliant.Forms.MainForm));
			this.notifyIcon = new global::System.Windows.Forms.NotifyIcon(this.components);
			this.mainMenuStrip = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.refreshMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.saveMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.settingsMenuStrip = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.activeSettingsMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.providerSettingsMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.providerMenuStrip = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.bingProviderMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.spotlightProviderMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.styleSettingsMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.styleMenuStrip = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.centerStyleMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.tileStyleMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.stretchStyleMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.fitStyleMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.fillStyleMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.spanStyleMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.shareSettingsMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.launchSettingsMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.licenseMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.aboutMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.exitMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.refreshTimer = new global::System.Windows.Forms.Timer(this.components);
			this.saveFileDialog = new global::System.Windows.Forms.SaveFileDialog();
			this.refreshWorker = new global::System.ComponentModel.BackgroundWorker();
			this.mainMenuStrip.SuspendLayout();
			this.settingsMenuStrip.SuspendLayout();
			this.providerMenuStrip.SuspendLayout();
			this.styleMenuStrip.SuspendLayout();
			base.SuspendLayout();
			this.notifyIcon.BalloonTipText = "Change your wallpaper to the astonishing images daily";
			this.notifyIcon.BalloonTipTitle = "Wallpaper changer";
			this.notifyIcon.ContextMenuStrip = this.mainMenuStrip;
			this.notifyIcon.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("notifyIcon.Icon");
			this.notifyIcon.Text = "Wallpaper manager";
			this.notifyIcon.Visible = true;
			this.mainMenuStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.refreshMenuItem,
				this.saveMenuItem,
				this.settingsToolStripMenuItem,
				this.licenseMenuItem,
				this.aboutMenuItem,
				this.exitMenuItem
			});
			this.mainMenuStrip.Name = "contextMenuStrip1";
			this.mainMenuStrip.ShowCheckMargin = true;
			this.mainMenuStrip.ShowImageMargin = false;
			this.mainMenuStrip.Size = new global::System.Drawing.Size(187, 136);
			this.mainMenuStrip.Closing += new global::System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.HandleMainMenuClosing);
			this.mainMenuStrip.Opening += new global::System.ComponentModel.CancelEventHandler(this.HandleMainMenuOpening);
			this.refreshMenuItem.Enabled = false;
			this.refreshMenuItem.Name = "refreshMenuItem";
			this.refreshMenuItem.Size = new global::System.Drawing.Size(186, 22);
			this.refreshMenuItem.Text = "Next Wallpaper";
			this.refreshMenuItem.Click += new global::System.EventHandler(this.HandleRefreshMenuItemClick);
			this.saveMenuItem.Enabled = false;
			this.saveMenuItem.Name = "saveMenuItem";
			this.saveMenuItem.Size = new global::System.Drawing.Size(186, 22);
			this.saveMenuItem.Text = "Save Wallpaper to PC";
			this.saveMenuItem.Click += new global::System.EventHandler(this.HandleSaveMenuItemClick);
			this.settingsToolStripMenuItem.DropDown = this.settingsMenuStrip;
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new global::System.Drawing.Size(186, 22);
			this.settingsToolStripMenuItem.Text = "Settings";
			this.settingsMenuStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.activeSettingsMenuItem,
				this.providerSettingsMenuItem,
				this.styleSettingsMenuItem,
				this.shareSettingsMenuItem,
				this.launchSettingsMenuItem
			});
			this.settingsMenuStrip.Name = "settingsMenuStrip";
			this.settingsMenuStrip.OwnerItem = this.settingsToolStripMenuItem;
			this.settingsMenuStrip.ShowCheckMargin = true;
			this.settingsMenuStrip.ShowImageMargin = false;
			this.settingsMenuStrip.Size = new global::System.Drawing.Size(180, 114);
			this.settingsMenuStrip.Closing += new global::System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.HandleSettingsMenuClosing);
			this.settingsMenuStrip.Opening += new global::System.ComponentModel.CancelEventHandler(this.HandleSettingsMenuOpening);
			this.activeSettingsMenuItem.Enabled = false;
			this.activeSettingsMenuItem.Name = "activeSettingsMenuItem";
			this.activeSettingsMenuItem.Size = new global::System.Drawing.Size(179, 22);
			this.activeSettingsMenuItem.Text = "Change image daily";
			this.activeSettingsMenuItem.Click += new global::System.EventHandler(this.HandleActiveSettingsMenuItemClick);
			this.providerSettingsMenuItem.DropDown = this.providerMenuStrip;
			this.providerSettingsMenuItem.Enabled = false;
			this.providerSettingsMenuItem.Name = "providerSettingsMenuItem";
			this.providerSettingsMenuItem.Size = new global::System.Drawing.Size(179, 22);
			this.providerSettingsMenuItem.Text = "Image source";
			this.providerMenuStrip.Enabled = false;
			this.providerMenuStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.bingProviderMenuItem,
				this.spotlightProviderMenuItem
			});
			this.providerMenuStrip.Name = "providerMenuStrip";
			this.providerMenuStrip.OwnerItem = this.providerSettingsMenuItem;
			this.providerMenuStrip.ShowCheckMargin = true;
			this.providerMenuStrip.ShowImageMargin = false;
			this.providerMenuStrip.Size = new global::System.Drawing.Size(123, 48);
			this.providerMenuStrip.Closing += new global::System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.HandleProviderMenuClosing);
			this.providerMenuStrip.Opening += new global::System.ComponentModel.CancelEventHandler(this.HandleProviderMenuOpening);
			this.bingProviderMenuItem.Enabled = false;
			this.bingProviderMenuItem.Name = "bingProviderMenuItem";
			this.bingProviderMenuItem.Size = new global::System.Drawing.Size(122, 22);
			this.bingProviderMenuItem.Text = "Bing";
			this.bingProviderMenuItem.Click += new global::System.EventHandler(this.HandleBingProviderMenuItemClick);
			this.spotlightProviderMenuItem.Enabled = false;
			this.spotlightProviderMenuItem.Name = "spotlightProviderMenuItem";
			this.spotlightProviderMenuItem.Size = new global::System.Drawing.Size(122, 22);
			this.spotlightProviderMenuItem.Text = "Spotlight";
			this.spotlightProviderMenuItem.Click += new global::System.EventHandler(this.HandleSpotlightProviderMenuItemClick);
			this.styleSettingsMenuItem.DropDown = this.styleMenuStrip;
			this.styleSettingsMenuItem.Enabled = false;
			this.styleSettingsMenuItem.Name = "styleSettingsMenuItem";
			this.styleSettingsMenuItem.Size = new global::System.Drawing.Size(179, 22);
			this.styleSettingsMenuItem.Text = "Image style";
			this.styleMenuStrip.Enabled = false;
			this.styleMenuStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.centerStyleMenuItem,
				this.tileStyleMenuItem,
				this.stretchStyleMenuItem,
				this.fitStyleMenuItem,
				this.fillStyleMenuItem,
				this.spanStyleMenuItem
			});
			this.styleMenuStrip.Name = "styleMenuStrip";
			this.styleMenuStrip.OwnerItem = this.styleSettingsMenuItem;
			this.styleMenuStrip.Size = new global::System.Drawing.Size(112, 136);
			this.styleMenuStrip.Closing += new global::System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.HandleStyleMenuClosing);
			this.styleMenuStrip.Opening += new global::System.ComponentModel.CancelEventHandler(this.HandleStyleMenuOpening);
			this.centerStyleMenuItem.Enabled = false;
			this.centerStyleMenuItem.Name = "centerStyleMenuItem";
			this.centerStyleMenuItem.Size = new global::System.Drawing.Size(111, 22);
			this.centerStyleMenuItem.Text = "Center";
			this.centerStyleMenuItem.Click += new global::System.EventHandler(this.HandleCenterStyleMenuItemClick);
			this.tileStyleMenuItem.Enabled = false;
			this.tileStyleMenuItem.Name = "tileStyleMenuItem";
			this.tileStyleMenuItem.Size = new global::System.Drawing.Size(111, 22);
			this.tileStyleMenuItem.Text = "Tile";
			this.tileStyleMenuItem.Click += new global::System.EventHandler(this.HandleTileStyleMenuItemClick);
			this.stretchStyleMenuItem.Enabled = false;
			this.stretchStyleMenuItem.Name = "stretchStyleMenuItem";
			this.stretchStyleMenuItem.Size = new global::System.Drawing.Size(111, 22);
			this.stretchStyleMenuItem.Text = "Stretch";
			this.stretchStyleMenuItem.Click += new global::System.EventHandler(this.HandleStretchStyleMenuItemClick);
			this.fitStyleMenuItem.Enabled = false;
			this.fitStyleMenuItem.Name = "fitStyleMenuItem";
			this.fitStyleMenuItem.Size = new global::System.Drawing.Size(111, 22);
			this.fitStyleMenuItem.Text = "Fit";
			this.fitStyleMenuItem.Click += new global::System.EventHandler(this.HandleFitStyleMenuItemClick);
			this.fillStyleMenuItem.Enabled = false;
			this.fillStyleMenuItem.Name = "fillStyleMenuItem";
			this.fillStyleMenuItem.Size = new global::System.Drawing.Size(111, 22);
			this.fillStyleMenuItem.Text = "Fill";
			this.fillStyleMenuItem.Click += new global::System.EventHandler(this.HandleFillStyleMenuItemClick);
			this.spanStyleMenuItem.Enabled = false;
			this.spanStyleMenuItem.Name = "spanStyleMenuItem";
			this.spanStyleMenuItem.Size = new global::System.Drawing.Size(111, 22);
			this.spanStyleMenuItem.Text = "Span";
			this.spanStyleMenuItem.Click += new global::System.EventHandler(this.HandleSpanStyleMenuItemClick);
			this.shareSettingsMenuItem.Name = "shareSettingsMenuItem";
			this.shareSettingsMenuItem.Size = new global::System.Drawing.Size(179, 22);
			this.shareSettingsMenuItem.Text = "Share resources";
			this.shareSettingsMenuItem.Click += new global::System.EventHandler(this.HandleShareSettingsMenuItemClick);
			this.launchSettingsMenuItem.Name = "launchSettingsMenuItem";
			this.launchSettingsMenuItem.Size = new global::System.Drawing.Size(179, 22);
			this.launchSettingsMenuItem.Text = "Launch on startup";
			this.launchSettingsMenuItem.Click += new global::System.EventHandler(this.HandleLaunchSettingsMenuItemClick);
			this.licenseMenuItem.Name = "licenseMenuItem";
			this.licenseMenuItem.Size = new global::System.Drawing.Size(186, 22);
			this.licenseMenuItem.Text = "License";
			this.licenseMenuItem.Click += new global::System.EventHandler(this.HandleLicenseMenuItemClick);
			this.aboutMenuItem.Name = "aboutMenuItem";
			this.aboutMenuItem.Size = new global::System.Drawing.Size(186, 22);
			this.aboutMenuItem.Text = "About";
			this.aboutMenuItem.Click += new global::System.EventHandler(this.HandleAboutMenuItemClick);
			this.exitMenuItem.Name = "exitMenuItem";
			this.exitMenuItem.Size = new global::System.Drawing.Size(186, 22);
			this.exitMenuItem.Text = "Exit";
			this.exitMenuItem.Click += new global::System.EventHandler(this.HandleExitMenuItemClick);
			this.refreshTimer.Tick += new global::System.EventHandler(this.HandleRefreshTimerTick);
			this.saveFileDialog.FileName = "image";
			this.saveFileDialog.Filter = "PNG|*.png|JPG|*.jpg|BMP|*.bmp|GIF|*.gif";
			this.saveFileDialog.Title = "Save Wallpaper As";
			this.saveFileDialog.FileOk += new global::System.ComponentModel.CancelEventHandler(this.HandleSaveFileDialogFileOk);
			this.refreshWorker.WorkerSupportsCancellation = true;
			this.refreshWorker.DoWork += new global::System.ComponentModel.DoWorkEventHandler(this.HandleRefreshWorkerStarted);
			this.refreshWorker.RunWorkerCompleted += new global::System.ComponentModel.RunWorkerCompletedEventHandler(this.HandleRefreshWorkerFinished);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(800, 450);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "MainForm";
			this.Text = "Walliant";
			base.FormCreated += new global::System.EventHandler(this.HandleFormCreated);
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.HandleFormClosed);
			this.mainMenuStrip.ResumeLayout(false);
			this.settingsMenuStrip.ResumeLayout(false);
			this.providerMenuStrip.ResumeLayout(false);
			this.styleMenuStrip.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000073 RID: 115
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000074 RID: 116
		private global::System.Windows.Forms.NotifyIcon notifyIcon;

		// Token: 0x04000075 RID: 117
		private global::System.Windows.Forms.ContextMenuStrip mainMenuStrip;

		// Token: 0x04000076 RID: 118
		private global::System.Windows.Forms.ToolStripMenuItem licenseMenuItem;

		// Token: 0x04000077 RID: 119
		private global::System.Windows.Forms.ToolStripMenuItem refreshMenuItem;

		// Token: 0x04000078 RID: 120
		private global::System.Windows.Forms.ToolStripMenuItem saveMenuItem;

		// Token: 0x04000079 RID: 121
		private global::System.Windows.Forms.Timer refreshTimer;

		// Token: 0x0400007A RID: 122
		private global::System.Windows.Forms.ToolStripMenuItem exitMenuItem;

		// Token: 0x0400007B RID: 123
		private global::System.Windows.Forms.SaveFileDialog saveFileDialog;

		// Token: 0x0400007C RID: 124
		private global::System.ComponentModel.BackgroundWorker refreshWorker;

		// Token: 0x0400007D RID: 125
		private global::System.Windows.Forms.ContextMenuStrip providerMenuStrip;

		// Token: 0x0400007E RID: 126
		private global::System.Windows.Forms.ToolStripMenuItem bingProviderMenuItem;

		// Token: 0x0400007F RID: 127
		private global::System.Windows.Forms.ToolStripMenuItem spotlightProviderMenuItem;

		// Token: 0x04000080 RID: 128
		private global::System.Windows.Forms.ContextMenuStrip styleMenuStrip;

		// Token: 0x04000081 RID: 129
		private global::System.Windows.Forms.ToolStripMenuItem centerStyleMenuItem;

		// Token: 0x04000082 RID: 130
		private global::System.Windows.Forms.ToolStripMenuItem tileStyleMenuItem;

		// Token: 0x04000083 RID: 131
		private global::System.Windows.Forms.ToolStripMenuItem stretchStyleMenuItem;

		// Token: 0x04000084 RID: 132
		private global::System.Windows.Forms.ToolStripMenuItem fitStyleMenuItem;

		// Token: 0x04000085 RID: 133
		private global::System.Windows.Forms.ToolStripMenuItem fillStyleMenuItem;

		// Token: 0x04000086 RID: 134
		private global::System.Windows.Forms.ToolStripMenuItem spanStyleMenuItem;

		// Token: 0x04000087 RID: 135
		private global::System.Windows.Forms.ContextMenuStrip settingsMenuStrip;

		// Token: 0x04000088 RID: 136
		private global::System.Windows.Forms.ToolStripMenuItem activeSettingsMenuItem;

		// Token: 0x04000089 RID: 137
		private global::System.Windows.Forms.ToolStripMenuItem providerSettingsMenuItem;

		// Token: 0x0400008A RID: 138
		private global::System.Windows.Forms.ToolStripMenuItem styleSettingsMenuItem;

		// Token: 0x0400008B RID: 139
		private global::System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;

		// Token: 0x0400008C RID: 140
		private global::System.Windows.Forms.ToolStripMenuItem aboutMenuItem;

		// Token: 0x0400008D RID: 141
		private global::System.Windows.Forms.ToolStripMenuItem shareSettingsMenuItem;

		// Token: 0x0400008E RID: 142
		private global::System.Windows.Forms.ToolStripMenuItem launchSettingsMenuItem;
	}
}
