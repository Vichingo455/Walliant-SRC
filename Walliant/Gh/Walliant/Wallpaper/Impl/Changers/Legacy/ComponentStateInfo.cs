using System;
using System.Runtime.InteropServices;

namespace Gh.Walliant.Wallpaper.Impl.Changers.Legacy
{
	// Token: 0x02000026 RID: 38
	internal struct ComponentStateInfo
	{
		// Token: 0x0400005B RID: 91
		[MarshalAs(UnmanagedType.U4)]
		public uint Size;

		// Token: 0x0400005C RID: 92
		[MarshalAs(UnmanagedType.I4)]
		public int Left;

		// Token: 0x0400005D RID: 93
		[MarshalAs(UnmanagedType.I4)]
		public int Top;

		// Token: 0x0400005E RID: 94
		[MarshalAs(UnmanagedType.U4)]
		public uint Width;

		// Token: 0x0400005F RID: 95
		[MarshalAs(UnmanagedType.U4)]
		public uint Height;

		// Token: 0x04000060 RID: 96
		[MarshalAs(UnmanagedType.U4)]
		public uint ItemState;
	}
}
