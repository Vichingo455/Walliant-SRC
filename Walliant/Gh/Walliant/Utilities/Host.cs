using System;

namespace Gh.Walliant.Utilities
{
	// Token: 0x0200002E RID: 46
	internal static class Host
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x0000456A File Offset: 0x0000276A
		public static bool Legacy
		{
			get
			{
				return Environment.OSVersion.Version < new Version(6, 1);
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x00004582 File Offset: 0x00002782
		public static bool Modern
		{
			get
			{
				return Environment.OSVersion.Version >= new Version(6, 2);
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x0000459A File Offset: 0x0000279A
		public static bool Supported
		{
			get
			{
				return !Host.Legacy;
			}
		}
	}
}
