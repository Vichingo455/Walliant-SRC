using System;
using System.Runtime.InteropServices;

namespace Gh.Walliant.Wallpaper.Impl.Changers.Modern
{
	// Token: 0x0200001E RID: 30
	[Guid("B92B56A9-8B55-4E14-9A89-0199BBB6F93B")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IDesktopWallpaper
	{
		// Token: 0x06000032 RID: 50
		void SetWallpaper([MarshalAs(UnmanagedType.LPWStr)] string monitorID, [MarshalAs(UnmanagedType.LPWStr)] string wallpaper);

		// Token: 0x06000033 RID: 51
		void GetWallpaper([MarshalAs(UnmanagedType.LPWStr)] string monitorID, [MarshalAs(UnmanagedType.LPWStr)] out string wallpaper);

		// Token: 0x06000034 RID: 52
		void GetMonitorDevicePathAt([MarshalAs(UnmanagedType.U4)] uint monitorIndex, [MarshalAs(UnmanagedType.LPWStr)] out string monitorID);

		// Token: 0x06000035 RID: 53
		void GetMonitorDevicePathCount(out uint count);

		// Token: 0x06000036 RID: 54
		void GetMonitorRECT([MarshalAs(UnmanagedType.LPWStr)] string monitorID, [MarshalAs(UnmanagedType.Struct)] out Rect displayRect);

		// Token: 0x06000037 RID: 55
		void SetBackgroundColor([MarshalAs(UnmanagedType.U4)] uint color);

		// Token: 0x06000038 RID: 56
		void GetBackgroundColor([MarshalAs(UnmanagedType.U4)] out uint color);

		// Token: 0x06000039 RID: 57
		void SetPosition([MarshalAs(UnmanagedType.I4)] DesktopWallpaperPosition position);

		// Token: 0x0600003A RID: 58
		void GetPosition([MarshalAs(UnmanagedType.I4)] out DesktopWallpaperPosition position);

		// Token: 0x0600003B RID: 59
		void SetSlideshow(IntPtr items);

		// Token: 0x0600003C RID: 60
		void GetSlideshow(out IntPtr items);

		// Token: 0x0600003D RID: 61
		void SetSlideshowOptions([MarshalAs(UnmanagedType.I4)] DesktopSlideshowOptions options, uint slideshowTick);

		// Token: 0x0600003E RID: 62
		void GetSlideshowOptions([MarshalAs(UnmanagedType.I4)] out DesktopSlideshowOptions options, out uint slideshowTick);

		// Token: 0x0600003F RID: 63
		void AdvanceSlideshow([MarshalAs(UnmanagedType.LPWStr)] string monitorID, [MarshalAs(UnmanagedType.I4)] DesktopSlideshowDirection direction);

		// Token: 0x06000040 RID: 64
		void GetStatus([MarshalAs(UnmanagedType.I4)] out DesktopSlideshowState state);

		// Token: 0x06000041 RID: 65
		void Enable([MarshalAs(UnmanagedType.Bool)] bool enable);
	}
}
