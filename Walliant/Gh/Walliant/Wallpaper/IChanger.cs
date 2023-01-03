using System;
using System.Drawing;

namespace Gh.Walliant.Wallpaper
{
	// Token: 0x02000006 RID: 6
	internal interface IChanger
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000F RID: 15
		// (set) Token: 0x06000010 RID: 16
		Image Image { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000011 RID: 17
		// (set) Token: 0x06000012 RID: 18
		Style Style { get; set; }
	}
}
