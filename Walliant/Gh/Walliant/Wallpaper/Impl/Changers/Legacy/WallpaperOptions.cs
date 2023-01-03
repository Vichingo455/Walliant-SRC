using System;
using System.Runtime.InteropServices;

namespace Gh.Walliant.Wallpaper.Impl.Changers.Legacy
{
	// Token: 0x02000029 RID: 41
	internal struct WallpaperOptions
	{
		// Token: 0x04000065 RID: 101
		[MarshalAs(UnmanagedType.U4)]
		public uint Size;

		// Token: 0x04000066 RID: 102
		[MarshalAs(UnmanagedType.U4)]
		public WallpaperStyle Style;
	}
}
