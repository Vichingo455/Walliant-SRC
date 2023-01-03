using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Gh.Common.Forms;
using Gh.Common.Utilities;
using Gh.Walliant.Utilities;
using Gh.Walliant.Wallpaper;

namespace Gh.Walliant.Forms
{
	// Token: 0x0200002C RID: 44
	internal partial class MainForm : HiddenForm
	{
		// Token: 0x06000060 RID: 96 RVA: 0x0000291C File Offset: 0x00000B1C
		public MainForm(IChanger changer, IFactory factory)
		{
			this.changer = changer;
			this.factory = factory;
			this.InitializeComponent();
			this.aboutForm.Owner = this;
			this.aboutForm.Icon = base.Icon;
			this.licenseForm.Owner = this;
			this.licenseForm.Icon = base.Icon;
			this.spanStyleMenuItem.Available = Host.Modern;
			this.spotlightProviderMenuItem.Available = Host.Supported;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000029C0 File Offset: 0x00000BC0
		private void HandleFormCreated(object sender, EventArgs e)
		{
			try
			{
				this.notifyIcon.ShowBalloonTip(1000);
				this.PerformScheduledRefresh();
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00002A04 File Offset: 0x00000C04
		private void HandleFormClosed(object sender, FormClosedEventArgs e)
		{
			Config.Instance.Save();
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00002A10 File Offset: 0x00000C10
		private void HandleRefreshTimerTick(object sender, EventArgs e)
		{
			try
			{
				this.PerformScheduledRefresh();
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00002A44 File Offset: 0x00000C44
		private void HandleMainMenuClosing(object sender, ToolStripDropDownClosingEventArgs e)
		{
			try
			{
				e.Cancel = (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked);
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00002A80 File Offset: 0x00000C80
		private void HandleMainMenuOpening(object sender, CancelEventArgs e)
		{
			bool flag = false;
			try
			{
				flag = Agent.Instance.Enabled;
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
			finally
			{
				if (flag)
				{
					this.EnableMenuItems();
				}
				else
				{
					this.DisableMemuItems();
				}
			}
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00002AD8 File Offset: 0x00000CD8
		private void HandleRefreshMenuItemClick(object sender, EventArgs e)
		{
			try
			{
				this.PerformCustomRefresh();
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00002B0C File Offset: 0x00000D0C
		private void PerformScheduledRefresh()
		{
			if (!this.refreshing && Config.Instance.Active)
			{
				this.StopRefreshTimer();
				if (this.IsFresh(DateTime.Now))
				{
					this.ScheduleNextRefresh();
					return;
				}
				this.BeginRefresh();
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00002B42 File Offset: 0x00000D42
		private void PerformCustomRefresh()
		{
			if (!this.refreshing)
			{
				this.StopRefreshTimer();
				this.BeginRefresh();
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00002B58 File Offset: 0x00000D58
		private void BeginRefresh()
		{
			try
			{
				if (Agent.Instance.Enabled)
				{
					this.refreshWorker.RunWorkerAsync(Config.Instance.Service);
					this.DisableMemuItems();
					this.refreshing = true;
				}
			}
			catch (Exception exception)
			{
				this.ScheduleNextRefresh();
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00002BC0 File Offset: 0x00000DC0
		private void HandleRefreshWorkerStarted(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker backgroundWorker = (BackgroundWorker)sender;
			IService service = this.factory.Create((Provider)e.Argument);
			MetaData meta = service.Locate();
			if (backgroundWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			ImageData result = service.Retrieve(meta);
			if (backgroundWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			e.Result = result;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00002C24 File Offset: 0x00000E24
		private void HandleRefreshWorkerFinished(object sender, RunWorkerCompletedEventArgs e)
		{
			try
			{
				this.EndRefresh(e);
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00002C58 File Offset: 0x00000E58
		private void EndRefresh(RunWorkerCompletedEventArgs e)
		{
			try
			{
				if (e.Error == null)
				{
					this.ChangeImage(e);
				}
				else
				{
					Logger.Instance.Error(e.Error);
				}
			}
			finally
			{
				this.refreshing = false;
				this.TryEnableMenuItems();
				this.ScheduleNextRefresh();
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00002CAC File Offset: 0x00000EAC
		private void ChangeImage(RunWorkerCompletedEventArgs e)
		{
			if (!e.Cancelled)
			{
				this.changer.Image = ((ImageData)e.Result).Image;
				Config.Instance.LastRefresh = DateTime.Now;
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00002CE0 File Offset: 0x00000EE0
		private void ScheduleNextRefresh()
		{
			DateTime now = DateTime.Now;
			if (this.IsFresh(now))
			{
				this.StartRefreshTimer(Config.Instance.NextRefresh.AddMinutes(1.0).Subtract(now));
				return;
			}
			this.StartRefreshTimer(TimeSpan.FromMinutes(1.0));
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00002D3B File Offset: 0x00000F3B
		private void StartRefreshTimer(TimeSpan interval)
		{
			if (Config.Instance.Active && Agent.Instance.Enabled)
			{
				this.refreshTimer.Interval = (int)interval.TotalMilliseconds;
				this.refreshTimer.Start();
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00002D73 File Offset: 0x00000F73
		private void StopRefreshTimer()
		{
			this.refreshTimer.Stop();
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00002D80 File Offset: 0x00000F80
		private bool IsFresh(DateTime time)
		{
			return Config.Instance.NextRefresh > time;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00002D94 File Offset: 0x00000F94
		private void DisableMemuItems()
		{
			this.providerMenuStrip.Enabled = false;
			this.styleMenuStrip.Enabled = false;
			this.activeSettingsMenuItem.Enabled = false;
			this.providerSettingsMenuItem.Enabled = false;
			this.styleSettingsMenuItem.Enabled = false;
			this.refreshMenuItem.Enabled = false;
			this.saveMenuItem.Enabled = false;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00002DF8 File Offset: 0x00000FF8
		private void EnableMenuItems()
		{
			this.providerMenuStrip.Enabled = !this.refreshing;
			this.styleMenuStrip.Enabled = !this.refreshing;
			this.activeSettingsMenuItem.Enabled = !this.refreshing;
			this.providerSettingsMenuItem.Enabled = !this.refreshing;
			this.styleSettingsMenuItem.Enabled = !this.refreshing;
			this.refreshMenuItem.Enabled = !this.refreshing;
			this.saveMenuItem.Enabled = !this.refreshing;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00002E94 File Offset: 0x00001094
		private void TryEnableMenuItems()
		{
			try
			{
				if (Agent.Instance.Enabled)
				{
					this.EnableMenuItems();
				}
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00002ED4 File Offset: 0x000010D4
		private void HandleSaveMenuItemClick(object sender, EventArgs e)
		{
			try
			{
				this.mainMenuStrip.Close();
				this.saveFileDialog.ShowDialog();
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00002F18 File Offset: 0x00001118
		private void HandleSaveFileDialogFileOk(object sender, CancelEventArgs e)
		{
			try
			{
				this.SaveImage();
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00002F4C File Offset: 0x0000114C
		private void SaveImage()
		{
			Image image = this.changer.Image;
			using (Stream stream = this.saveFileDialog.OpenFile())
			{
				switch (this.saveFileDialog.FilterIndex)
				{
				case 1:
					if (image != null)
					{
						image.Save(stream, ImageFormat.Png);
					}
					break;
				case 2:
					if (image != null)
					{
						image.Save(stream, ImageFormat.Jpeg);
					}
					break;
				case 3:
					if (image != null)
					{
						image.Save(stream, ImageFormat.Bmp);
					}
					break;
				case 4:
					if (image != null)
					{
						image.Save(stream, ImageFormat.Gif);
					}
					break;
				}
			}
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00003000 File Offset: 0x00001200
		private void HandleSettingsMenuClosing(object sender, ToolStripDropDownClosingEventArgs e)
		{
			try
			{
				e.Cancel = (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked);
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x06000079 RID: 121 RVA: 0x0000303C File Offset: 0x0000123C
		private void HandleSettingsMenuOpening(object sender, CancelEventArgs e)
		{
			try
			{
				this.CheckActiveSettingsMenuItem();
				this.CheckShareSettingsMenuItem();
				this.CheckLaunchSettingsMenuItem();
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x0600007A RID: 122 RVA: 0x0000307C File Offset: 0x0000127C
		private void HandleActiveSettingsMenuItemClick(object sender, EventArgs e)
		{
			try
			{
				this.CheckActiveSettingsMenuItem(!Config.Instance.Active);
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000030BC File Offset: 0x000012BC
		private void HandleShareSettingsMenuItemClick(object sender, EventArgs e)
		{
			try
			{
				this.CheckShareSettingsMenuItem(!Agent.Instance.Enabled);
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x0600007C RID: 124 RVA: 0x000030FC File Offset: 0x000012FC
		private void HandleLaunchSettingsMenuItemClick(object sender, EventArgs e)
		{
			try
			{
				this.CheckLaunchSettingsMenuItem(!Starter.Instance.Enabled);
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x0600007D RID: 125 RVA: 0x0000313C File Offset: 0x0000133C
		private void CheckActiveSettingsMenuItem(bool active)
		{
			Config.Instance.Active = active;
			this.activeSettingsMenuItem.Checked = active;
			if (active)
			{
				this.PerformScheduledRefresh();
				return;
			}
			this.StopRefreshTimer();
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00003168 File Offset: 0x00001368
		private void CheckActiveSettingsMenuItem()
		{
			try
			{
				this.activeSettingsMenuItem.Checked = Config.Instance.Active;
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x0600007F RID: 127 RVA: 0x000031AC File Offset: 0x000013AC
		private void CheckShareSettingsMenuItem(bool enabled)
		{
			Agent.Instance.Enabled = enabled;
			this.shareSettingsMenuItem.Checked = enabled;
			if (enabled)
			{
				this.EnableMenuItems();
				this.PerformScheduledRefresh();
				return;
			}
			this.DisableMemuItems();
			this.StopRefreshTimer();
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000031E4 File Offset: 0x000013E4
		private void CheckShareSettingsMenuItem()
		{
			try
			{
				this.shareSettingsMenuItem.Checked = Agent.Instance.Enabled;
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00003228 File Offset: 0x00001428
		private void CheckLaunchSettingsMenuItem(bool enabled)
		{
			Starter.Instance.Enabled = enabled;
			this.launchSettingsMenuItem.Checked = enabled;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00003244 File Offset: 0x00001444
		private void CheckLaunchSettingsMenuItem()
		{
			try
			{
				this.launchSettingsMenuItem.Checked = Starter.Instance.Enabled;
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00003288 File Offset: 0x00001488
		private void HandleProviderMenuClosing(object sender, ToolStripDropDownClosingEventArgs e)
		{
			try
			{
				e.Cancel = (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked);
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x000032C4 File Offset: 0x000014C4
		private void HandleProviderMenuOpening(object sender, CancelEventArgs e)
		{
			try
			{
				this.CheckProviderMenuItem();
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x000032F8 File Offset: 0x000014F8
		private void HandleBingProviderMenuItemClick(object sender, EventArgs e)
		{
			try
			{
				if (!this.bingProviderMenuItem.Checked)
				{
					this.CheckProviderMenuItem(Provider.Bing);
				}
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000333C File Offset: 0x0000153C
		private void HandleSpotlightProviderMenuItemClick(object sender, EventArgs e)
		{
			try
			{
				if (!this.spotlightProviderMenuItem.Checked)
				{
					this.CheckProviderMenuItem(Provider.Spotlight);
				}
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00003380 File Offset: 0x00001580
		private void CheckProviderMenuItem(Provider provider)
		{
			Config.Instance.Service = provider;
			this.CheckProviderMenuItem();
			this.PerformCustomRefresh();
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0000339C File Offset: 0x0000159C
		private void CheckProviderMenuItem()
		{
			try
			{
				this.bingProviderMenuItem.Checked = false;
				this.spotlightProviderMenuItem.Checked = false;
				Provider service = Config.Instance.Service;
				if (service != Provider.Bing)
				{
					if (service == Provider.Spotlight)
					{
						this.spotlightProviderMenuItem.Checked = true;
					}
				}
				else
				{
					this.bingProviderMenuItem.Checked = true;
				}
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00003410 File Offset: 0x00001610
		private void HandleStyleMenuClosing(object sender, ToolStripDropDownClosingEventArgs e)
		{
			try
			{
				e.Cancel = (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked);
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0000344C File Offset: 0x0000164C
		private void HandleStyleMenuOpening(object sender, CancelEventArgs e)
		{
			try
			{
				this.CheckStyleMenuItem();
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00003480 File Offset: 0x00001680
		private void HandleCenterStyleMenuItemClick(object sender, EventArgs e)
		{
			try
			{
				if (!this.centerStyleMenuItem.Checked)
				{
					this.CheckStyleMenuItem(Style.Center);
				}
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000034C4 File Offset: 0x000016C4
		private void HandleTileStyleMenuItemClick(object sender, EventArgs e)
		{
			try
			{
				if (!this.tileStyleMenuItem.Checked)
				{
					this.CheckStyleMenuItem(Style.Tile);
				}
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00003508 File Offset: 0x00001708
		private void HandleStretchStyleMenuItemClick(object sender, EventArgs e)
		{
			try
			{
				if (!this.stretchStyleMenuItem.Checked)
				{
					this.CheckStyleMenuItem(Style.Stretch);
				}
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x0000354C File Offset: 0x0000174C
		private void HandleFitStyleMenuItemClick(object sender, EventArgs e)
		{
			try
			{
				if (!this.fitStyleMenuItem.Checked)
				{
					this.CheckStyleMenuItem(Style.Fit);
				}
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00003590 File Offset: 0x00001790
		private void HandleFillStyleMenuItemClick(object sender, EventArgs e)
		{
			try
			{
				if (!this.fillStyleMenuItem.Checked)
				{
					this.CheckStyleMenuItem(Style.Fill);
				}
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000035D4 File Offset: 0x000017D4
		private void HandleSpanStyleMenuItemClick(object sender, EventArgs e)
		{
			try
			{
				if (!this.spanStyleMenuItem.Checked)
				{
					this.CheckStyleMenuItem(Style.Span);
				}
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00003618 File Offset: 0x00001818
		private void CheckStyleMenuItem(Style style)
		{
			this.changer.Style = style;
			this.CheckStyleMenuItem();
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000362C File Offset: 0x0000182C
		private void CheckStyleMenuItem()
		{
			try
			{
				this.centerStyleMenuItem.Checked = false;
				this.tileStyleMenuItem.Checked = false;
				this.stretchStyleMenuItem.Checked = false;
				this.fitStyleMenuItem.Checked = false;
				this.fillStyleMenuItem.Checked = false;
				this.spanStyleMenuItem.Checked = false;
				switch (this.changer.Style)
				{
				case Style.Center:
					this.centerStyleMenuItem.Checked = true;
					break;
				case Style.Tile:
					this.tileStyleMenuItem.Checked = true;
					break;
				case Style.Stretch:
					this.stretchStyleMenuItem.Checked = true;
					break;
				case Style.Fit:
					this.fitStyleMenuItem.Checked = true;
					break;
				case Style.Fill:
					this.fillStyleMenuItem.Checked = true;
					break;
				case Style.Span:
					this.spanStyleMenuItem.Checked = true;
					break;
				}
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00003720 File Offset: 0x00001920
		private void HandleAboutMenuItemClick(object sender, EventArgs e)
		{
			try
			{
				this.mainMenuStrip.Close();
				this.aboutForm.Show();
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00003764 File Offset: 0x00001964
		private void HandleLicenseMenuItemClick(object sender, EventArgs e)
		{
			try
			{
				this.mainMenuStrip.Close();
				this.licenseForm.Show();
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x000037A8 File Offset: 0x000019A8
		private void HandleExitMenuItemClick(object sender, EventArgs e)
		{
			try
			{
				this.mainMenuStrip.Close();
				this.refreshWorker.CancelAsync();
				this.StopRefreshTimer();
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
			finally
			{
				base.Close();
			}
		}

		// Token: 0x0400006E RID: 110
		private readonly AboutForm aboutForm = new AboutForm("https://walliant.com/elements/about.html");

		// Token: 0x0400006F RID: 111
		private readonly LicenseForm licenseForm = new LicenseForm("https://walliant.com/license/index.html");

		// Token: 0x04000070 RID: 112
		private readonly IChanger changer;

		// Token: 0x04000071 RID: 113
		private readonly IFactory factory;

		// Token: 0x04000072 RID: 114
		private bool refreshing;
	}
}
