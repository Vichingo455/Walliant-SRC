using System;

namespace Gh.Walliant.Wallpaper
{
	// Token: 0x02000007 RID: 7
	internal interface IService
	{
		// Token: 0x06000013 RID: 19
		MetaData Locate();

		// Token: 0x06000014 RID: 20
		ImageData Retrieve(MetaData meta);
	}
}
