using System;
using System.Runtime.InteropServices;

namespace Gh.Walliant.Wallpaper.Impl.Changers.Legacy
{
	// Token: 0x02000024 RID: 36
	internal struct ComponentOptions
	{
		// Token: 0x0400004D RID: 77
		[MarshalAs(UnmanagedType.U4)]
		public uint Size;

		// Token: 0x0400004E RID: 78
		[MarshalAs(UnmanagedType.Bool)]
		public bool EnableComponents;

		// Token: 0x0400004F RID: 79
		[MarshalAs(UnmanagedType.Bool)]
		public bool ActiveDesktop;
	}
}
