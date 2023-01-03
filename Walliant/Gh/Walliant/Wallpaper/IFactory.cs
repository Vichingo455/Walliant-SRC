using System;

namespace Gh.Walliant.Wallpaper
{
	// Token: 0x02000008 RID: 8
	internal interface IFactory
	{
		// Token: 0x06000015 RID: 21
		IService Create(Provider type);
	}
}
