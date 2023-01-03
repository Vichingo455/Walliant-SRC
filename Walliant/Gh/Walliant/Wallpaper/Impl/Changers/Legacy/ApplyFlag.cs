using System;

namespace Gh.Walliant.Wallpaper.Impl.Changers.Legacy
{
	// Token: 0x02000022 RID: 34
	[Flags]
	internal enum ApplyFlag
	{
		// Token: 0x04000039 RID: 57
		Save = 1,
		// Token: 0x0400003A RID: 58
		HtmlGen = 2,
		// Token: 0x0400003B RID: 59
		Refresh = 4,
		// Token: 0x0400003C RID: 60
		All = 7,
		// Token: 0x0400003D RID: 61
		Force = 8,
		// Token: 0x0400003E RID: 62
		BufferedRefresh = 16,
		// Token: 0x0400003F RID: 63
		DynamicRefresh = 32
	}
}
