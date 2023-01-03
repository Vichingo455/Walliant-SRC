using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Net;
using Newtonsoft.Json;

namespace Gh.Walliant.Wallpaper.Impl.Services.Spotlight
{
	// Token: 0x02000018 RID: 24
	internal class Service : Base
	{
		// Token: 0x0600002D RID: 45 RVA: 0x000025BC File Offset: 0x000007BC
		public override MetaData Locate()
		{
			MetaData result;
			using (WebClient webClient = new WebClient())
			{
				string response = this.Query(webClient);
				result = this.Parse(response);
			}
			return result;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000025FC File Offset: 0x000007FC
		private string Query(WebClient client)
		{
			client.BaseAddress = "https://arc.msn.com/";
			client.QueryString = new NameValueCollection
			{
				{
					"pid",
					"338387"
				},
				{
					"fmt",
					"json"
				},
				{
					"rafb",
					"0"
				},
				{
					"cdm",
					"1"
				},
				{
					"disphorzres",
					"1920"
				},
				{
					"dispvertres",
					"1080"
				},
				{
					"lo",
					"80217"
				},
				{
					"pl",
					"en-US"
				},
				{
					"lc",
					"en-US"
				},
				{
					"ctry",
					"US"
				},
				{
					"time",
					DateTime.UtcNow.Date.ToString("yyyy-MM-ddTHH:mm:ssK", CultureInfo.InvariantCulture)
				}
			};
			Uri address = new Uri("/v3/Delivery/Placement", UriKind.Relative);
			return client.DownloadString(address);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000026FC File Offset: 0x000008FC
		private MetaData Parse(string response)
		{
			Uri uri = new Uri(JsonConvert.DeserializeObject<EntryInfo>(JsonConvert.DeserializeObject<ResponseInfo>(response).batchrsp.items[0].item).ad.image_fullscreen_001_landscape.u);
			return new MetaData
			{
				Uri = uri
			};
		}
	}
}
