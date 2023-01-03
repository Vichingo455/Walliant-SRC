using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Gh.Walliant.Wallpaper.Impl.Changers.Legacy
{
	// Token: 0x02000028 RID: 40
	[Guid("F490EB00-1240-11D1-9888-006097DEACF9")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IActiveDesktop
	{
		// Token: 0x06000048 RID: 72
		void ApplyChanges([MarshalAs(UnmanagedType.U4)] ApplyFlag flags);

		// Token: 0x06000049 RID: 73
		void GetWallpaper([MarshalAs(UnmanagedType.LPWStr)] StringBuilder wallpaper, [MarshalAs(UnmanagedType.U4)] uint size, [MarshalAs(UnmanagedType.U4)] GetWallpaperFlag flag);

		// Token: 0x0600004A RID: 74
		void SetWallpaper([MarshalAs(UnmanagedType.LPWStr)] string wallpaper, [MarshalAs(UnmanagedType.U4)] uint reserved);

		// Token: 0x0600004B RID: 75
		void GetWallpaperOptions([MarshalAs(UnmanagedType.Struct)] ref WallpaperOptions options, [MarshalAs(UnmanagedType.U4)] uint reserved);

		// Token: 0x0600004C RID: 76
		void SetWallpaperOptions([MarshalAs(UnmanagedType.Struct)] in WallpaperOptions options, [MarshalAs(UnmanagedType.U4)] uint reserved);

		// Token: 0x0600004D RID: 77
		void GetPattern([MarshalAs(UnmanagedType.LPWStr)] StringBuilder pattern, [MarshalAs(UnmanagedType.U4)] uint size, [MarshalAs(UnmanagedType.U4)] uint reserved);

		// Token: 0x0600004E RID: 78
		void SetPattern([MarshalAs(UnmanagedType.LPWStr)] string pattern, [MarshalAs(UnmanagedType.U4)] uint reserved);

		// Token: 0x0600004F RID: 79
		void GetDesktopItemOptions([MarshalAs(UnmanagedType.Struct)] ref ComponentOptions options, [MarshalAs(UnmanagedType.U4)] uint reserved);

		// Token: 0x06000050 RID: 80
		void SetDesktopItemOptions([MarshalAs(UnmanagedType.Struct)] in ComponentOptions options, [MarshalAs(UnmanagedType.U4)] uint reserved);

		// Token: 0x06000051 RID: 81
		void AddDesktopItem([MarshalAs(UnmanagedType.Struct)] in Component component, [MarshalAs(UnmanagedType.U4)] uint reserved);

		// Token: 0x06000052 RID: 82
		void AddDesktopItemWithUI(UIntPtr handle, [MarshalAs(UnmanagedType.Struct)] in Component component, [MarshalAs(UnmanagedType.U4)] uint reserved);

		// Token: 0x06000053 RID: 83
		void ModifyDesktopItem([MarshalAs(UnmanagedType.Struct)] ref Component component, [MarshalAs(UnmanagedType.U4)] uint flags);

		// Token: 0x06000054 RID: 84
		void RemoveDesktopItem([MarshalAs(UnmanagedType.Struct)] in Component component, [MarshalAs(UnmanagedType.U4)] uint reserved);

		// Token: 0x06000055 RID: 85
		void GetDesktopItemCount([MarshalAs(UnmanagedType.I4)] out int count, [MarshalAs(UnmanagedType.U4)] uint reserved);

		// Token: 0x06000056 RID: 86
		void GetDesktopItem([MarshalAs(UnmanagedType.I4)] int index, [MarshalAs(UnmanagedType.Struct)] ref Component component, [MarshalAs(UnmanagedType.U4)] uint reserved);

		// Token: 0x06000057 RID: 87
		void GetDesktopItemByID(UIntPtr ID, [MarshalAs(UnmanagedType.Struct)] ref Component component, [MarshalAs(UnmanagedType.U4)] uint reserved);

		// Token: 0x06000058 RID: 88
		void GenerateDesktopItemHtml([MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.Struct)] in Component component, [MarshalAs(UnmanagedType.U4)] uint reserved);

		// Token: 0x06000059 RID: 89
		void AddUrl(UIntPtr handle, [MarshalAs(UnmanagedType.LPWStr)] string source, [MarshalAs(UnmanagedType.Struct)] in Component component, [MarshalAs(UnmanagedType.U4)] uint flags);

		// Token: 0x0600005A RID: 90
		void GetDesktopItemBySource([MarshalAs(UnmanagedType.LPWStr)] string source, [MarshalAs(UnmanagedType.Struct)] ref Component component, [MarshalAs(UnmanagedType.U4)] uint reserved);
	}
}
