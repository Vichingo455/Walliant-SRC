using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Gh.Walliant.Wallpaper.Impl.Changers.Legacy
{
	// Token: 0x0200002B RID: 43
	internal class Changer : IChanger
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600005B RID: 91 RVA: 0x000027F4 File Offset: 0x000009F4
		// (set) Token: 0x0600005C RID: 92 RVA: 0x0000283C File Offset: 0x00000A3C
		public Image Image
		{
			get
			{
				IActiveDesktop activeDesktop = (IActiveDesktop)new ActiveDesktop();
				StringBuilder stringBuilder = new StringBuilder(32767);
				activeDesktop.GetWallpaper(stringBuilder, (uint)stringBuilder.Capacity, GetWallpaperFlag.Bmp);
				string text = stringBuilder.ToString();
				if (!string.IsNullOrEmpty(text))
				{
					return Image.FromFile(text);
				}
				return null;
			}
			set
			{
				IActiveDesktop activeDesktop = (IActiveDesktop)new ActiveDesktop();
				string text = (value != null) ? Path.GetTempFileName() : string.Empty;
				if (value != null)
				{
					value.Save(text);
				}
				activeDesktop.SetWallpaper(text, 0U);
				activeDesktop.ApplyChanges(ApplyFlag.All);
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600005D RID: 93 RVA: 0x0000287C File Offset: 0x00000A7C
		// (set) Token: 0x0600005E RID: 94 RVA: 0x000028C4 File Offset: 0x00000AC4
		public Style Style
		{
			get
			{
				IActiveDesktop activeDesktop = (IActiveDesktop)new ActiveDesktop();
				int size = Marshal.SizeOf(typeof(WallpaperOptions));
				WallpaperOptions wallpaperOptions = new WallpaperOptions
				{
					Size = (uint)size
				};
				activeDesktop.GetWallpaperOptions(ref wallpaperOptions, 0U);
				return (Style)wallpaperOptions.Style;
			}
			set
			{
				IActiveDesktop activeDesktop = (IActiveDesktop)new ActiveDesktop();
				int size = Marshal.SizeOf(typeof(WallpaperOptions));
				WallpaperOptions wallpaperOptions = new WallpaperOptions
				{
					Size = (uint)size,
					Style = (WallpaperStyle)value
				};
				activeDesktop.SetWallpaperOptions(wallpaperOptions, 0U);
				activeDesktop.ApplyChanges(ApplyFlag.All);
			}
		}
	}
}
