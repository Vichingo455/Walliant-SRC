using System;
using System.Collections.Specialized;
using System.Net;
using Newtonsoft.Json;

namespace Gh.Walliant.Wallpaper.Impl.Services.Bing
{
	// Token: 0x02000011 RID: 17
	internal class Service : Base
	{
		// Token: 0x06000023 RID: 35 RVA: 0x00002408 File Offset: 0x00000608
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

		// Token: 0x06000024 RID: 36 RVA: 0x00002448 File Offset: 0x00000648
		private string Query(WebClient client)
		{
			client.BaseAddress = this.baseAddress;
			client.QueryString = new NameValueCollection
			{
				{
					"format",
					"js"
				},
				{
					"idx",
					"0"
				},
				{
					"mkt",
					"en-US"
				},
				{
					"n",
					"1"
				}
			};
			Uri address = new Uri("/HPImageArchive.aspx", UriKind.Relative);
			return client.DownloadString(address);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000024C0 File Offset: 0x000006C0
		private MetaData Parse(string response)
		{
			ResponseInfo responseInfo = JsonConvert.DeserializeObject<ResponseInfo>(response);
			Uri uri = new Uri(new Uri(this.baseAddress), responseInfo.images[0].url);
			return new MetaData
			{
				Uri = uri
			};
		}

		// Token: 0x04000014 RID: 20
		private readonly string baseAddress = "https://www.bing.com/";
	}
}
