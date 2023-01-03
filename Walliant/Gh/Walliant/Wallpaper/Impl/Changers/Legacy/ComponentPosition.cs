using System;
using System.Runtime.InteropServices;

namespace Gh.Walliant.Wallpaper.Impl.Changers.Legacy
{
	// Token: 0x02000025 RID: 37
	internal struct ComponentPosition
	{
		// Token: 0x04000050 RID: 80
		[MarshalAs(UnmanagedType.U4)]
		public uint Size;

		// Token: 0x04000051 RID: 81
		[MarshalAs(UnmanagedType.I4)]
		public int Left;

		// Token: 0x04000052 RID: 82
		[MarshalAs(UnmanagedType.I4)]
		public int Top;

		// Token: 0x04000053 RID: 83
		[MarshalAs(UnmanagedType.U4)]
		public uint Width;

		// Token: 0x04000054 RID: 84
		[MarshalAs(UnmanagedType.U4)]
		public uint Height;

		// Token: 0x04000055 RID: 85
		[MarshalAs(UnmanagedType.I4)]
		public int Index;

		// Token: 0x04000056 RID: 86
		[MarshalAs(UnmanagedType.Bool)]
		public bool CanResize;

		// Token: 0x04000057 RID: 87
		[MarshalAs(UnmanagedType.Bool)]
		public bool CanResizeX;

		// Token: 0x04000058 RID: 88
		[MarshalAs(UnmanagedType.Bool)]
		public bool CanResizeY;

		// Token: 0x04000059 RID: 89
		[MarshalAs(UnmanagedType.I4)]
		public int PreferredLeftPercent;

		// Token: 0x0400005A RID: 90
		[MarshalAs(UnmanagedType.I4)]
		public int PreferredTopPercent;
	}
}
