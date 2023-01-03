using System;
using System.Runtime.InteropServices;

namespace Gh.Walliant.Wallpaper.Impl.Changers.Modern
{
	// Token: 0x02000020 RID: 32
	internal struct Rect
	{
		// Token: 0x04000034 RID: 52
		[MarshalAs(UnmanagedType.I4)]
		public int Left;

		// Token: 0x04000035 RID: 53
		[MarshalAs(UnmanagedType.I4)]
		public int Top;

		// Token: 0x04000036 RID: 54
		[MarshalAs(UnmanagedType.I4)]
		public int Right;

		// Token: 0x04000037 RID: 55
		[MarshalAs(UnmanagedType.I4)]
		public int Bottom;
	}
}
