using System;
using System.Runtime.InteropServices;

namespace Gh.Walliant.Wallpaper.Impl.Changers.Legacy
{
	// Token: 0x02000023 RID: 35
	internal struct Component
	{
		// Token: 0x04000040 RID: 64
		[MarshalAs(UnmanagedType.U4)]
		public uint Size;

		// Token: 0x04000041 RID: 65
		[MarshalAs(UnmanagedType.U4)]
		public uint ID;

		// Token: 0x04000042 RID: 66
		[MarshalAs(UnmanagedType.I4)]
		public int ComponentType;

		// Token: 0x04000043 RID: 67
		[MarshalAs(UnmanagedType.Bool)]
		public bool Checked;

		// Token: 0x04000044 RID: 68
		[MarshalAs(UnmanagedType.Bool)]
		public bool Dirty;

		// Token: 0x04000045 RID: 69
		[MarshalAs(UnmanagedType.Bool)]
		public bool NoScroll;

		// Token: 0x04000046 RID: 70
		[MarshalAs(UnmanagedType.Struct)]
		private ComponentPosition Position;

		// Token: 0x04000047 RID: 71
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string FriendlyName;

		// Token: 0x04000048 RID: 72
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2084)]
		public string Source;

		// Token: 0x04000049 RID: 73
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2084)]
		public string SubscribedURL;

		// Token: 0x0400004A RID: 74
		[MarshalAs(UnmanagedType.U4)]
		public uint CurrentItemState;

		// Token: 0x0400004B RID: 75
		[MarshalAs(UnmanagedType.Struct)]
		private ComponentStateInfo Original;

		// Token: 0x0400004C RID: 76
		[MarshalAs(UnmanagedType.Struct)]
		private ComponentStateInfo Restored;
	}
}
