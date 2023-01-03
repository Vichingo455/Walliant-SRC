using System;
using Gh.Walliant.Utilities;
using Gh.Walliant.Wallpaper.Impl.Services.Bing;
using Gh.Walliant.Wallpaper.Impl.Services.Spotlight;

namespace Gh.Walliant.Wallpaper.Impl.Services
{
	// Token: 0x0200000E RID: 14
	internal class Factory : IFactory
	{
		// Token: 0x0600001F RID: 31 RVA: 0x00002384 File Offset: 0x00000584
		public IService Create(Provider type)
		{
			IService result;
			if (type != Provider.Bing)
			{
				if (type != Provider.Spotlight)
				{
					IService service2;
					if (!Host.Supported)
					{
						IService service = new Gh.Walliant.Wallpaper.Impl.Services.Bing.Service();
						service2 = service;
					}
					else
					{
						IService service = new Gh.Walliant.Wallpaper.Impl.Services.Spotlight.Service();
						service2 = service;
					}
					result = service2;
				}
				else
				{
					result = new Gh.Walliant.Wallpaper.Impl.Services.Spotlight.Service();
				}
			}
			else
			{
				result = new Gh.Walliant.Wallpaper.Impl.Services.Bing.Service();
			}
			return result;
		}
	}
}
