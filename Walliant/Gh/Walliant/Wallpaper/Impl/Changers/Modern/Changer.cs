using System;
using System.Drawing;
using System.IO;

namespace Gh.Walliant.Wallpaper.Impl.Changers.Modern
{
	// Token: 0x0200001F RID: 31
	internal class Changer : IChanger
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00002750 File Offset: 0x00000950
		// (set) Token: 0x06000043 RID: 67 RVA: 0x00002780 File Offset: 0x00000980
		public Image Image
		{
			get
			{
				string text;
				((IDesktopWallpaper)new DesktopWallpaper()).GetWallpaper(null, out text);
				if (!string.IsNullOrEmpty(text))
				{
					return Image.FromFile(text);
				}
				return null;
			}
			set
			{
				IDesktopWallpaper desktopWallpaper = (IDesktopWallpaper)new DesktopWallpaper();
				if (value != null)
				{
					string tempFileName = Path.GetTempFileName();
					value.Save(tempFileName);
					desktopWallpaper.SetWallpaper(null, tempFileName);
					return;
				}
				desktopWallpaper.Enable(false);
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000044 RID: 68 RVA: 0x000027B8 File Offset: 0x000009B8
		// (set) Token: 0x06000045 RID: 69 RVA: 0x000027D7 File Offset: 0x000009D7
		public Style Style
		{
			get
			{
				DesktopWallpaperPosition result;
				((IDesktopWallpaper)new DesktopWallpaper()).GetPosition(out result);
				return (Style)result;
			}
			set
			{
				((IDesktopWallpaper)new DesktopWallpaper()).SetPosition((DesktopWallpaperPosition)value);
			}
		}
	}
}
