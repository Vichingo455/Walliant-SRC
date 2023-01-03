using System;
using System.Drawing;
using System.IO;
using System.Net;

namespace Gh.Walliant.Wallpaper.Impl.Services
{
	// Token: 0x0200000D RID: 13
	internal abstract class Base : IService
	{
		// Token: 0x0600001C RID: 28
		public abstract MetaData Locate();

		// Token: 0x0600001D RID: 29 RVA: 0x00002314 File Offset: 0x00000514
		public ImageData Retrieve(MetaData meta)
		{
			ImageData result;
			using (WebClient webClient = new WebClient())
			{
				using (Stream stream = webClient.OpenRead(meta.Uri))
				{
					Image image = Image.FromStream(stream);
					result = new ImageData
					{
						Image = image
					};
				}
			}
			return result;
		}
	}
}
