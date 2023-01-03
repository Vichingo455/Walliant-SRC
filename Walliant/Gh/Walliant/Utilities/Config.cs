using System;
using System.Configuration;
using Gh.Common.Utilities;
using Gh.Walliant.Wallpaper;

namespace Gh.Walliant.Utilities
{
	// Token: 0x0200002D RID: 45
	internal sealed class Config : ConfigBase
	{
		// Token: 0x06000099 RID: 153 RVA: 0x000044B5 File Offset: 0x000026B5
		private Config()
		{
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600009A RID: 154 RVA: 0x000044BD File Offset: 0x000026BD
		public static Config Instance { get; } = new Config();

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600009B RID: 155 RVA: 0x000044C4 File Offset: 0x000026C4
		// (set) Token: 0x0600009C RID: 156 RVA: 0x000044D6 File Offset: 0x000026D6
		[UserScopedSetting]
		[DefaultSettingValue("False")]
		public bool Active
		{
			get
			{
				return (bool)this["Active"];
			}
			set
			{
				this["Active"] = value;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600009D RID: 157 RVA: 0x000044E9 File Offset: 0x000026E9
		// (set) Token: 0x0600009E RID: 158 RVA: 0x000044FB File Offset: 0x000026FB
		[UserScopedSetting]
		[DefaultSettingValue("")]
		public DateTime LastRefresh
		{
			get
			{
				return (DateTime)this["LastRefresh"];
			}
			set
			{
				this["LastRefresh"] = value;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600009F RID: 159 RVA: 0x00004510 File Offset: 0x00002710
		public DateTime NextRefresh
		{
			get
			{
				return this.LastRefresh.Date.AddDays(1.0);
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x0000453C File Offset: 0x0000273C
		// (set) Token: 0x060000A1 RID: 161 RVA: 0x00004557 File Offset: 0x00002757
		[UserScopedSetting]
		[DefaultSettingValue("Spotlight")]
		public Provider Service
		{
			get
			{
				if (!Host.Supported)
				{
					return Provider.Bing;
				}
				return (Provider)this["Service"];
			}
			set
			{
				this["Service"] = value;
			}
		}
	}
}
