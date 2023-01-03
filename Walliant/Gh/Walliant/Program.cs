using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Gh.Common.Utilities;
using Gh.Common.WinAPI.Enums;
using Gh.Walliant.Forms;
using Gh.Walliant.Utilities;
using Gh.Walliant.Wallpaper;
using Gh.Walliant.Wallpaper.Impl.Changers.Legacy;
using Gh.Walliant.Wallpaper.Impl.Changers.Modern;
using Gh.Walliant.Wallpaper.Impl.Services;

namespace Gh.Walliant
{
	// Token: 0x02000004 RID: 4
	internal static class Program
	{
		// Token: 0x06000003 RID: 3 RVA: 0x00002060 File Offset: 0x00000260
		[STAThread]
		private static void Main()
		{
			try
			{
				Logger.Instance.Init("https://25e5cccd5e35435e9399507e39a52b6d@o357035.ingest.sentry.io/5209089");
				bool flag;
				using (new Mutex(true, "Local\\{E8C20855-465C-411B-A0F9-6897240D9EB3}", ref flag))
				{
					if (flag)
					{
						Program.Run();
					}
				}
			}
			catch (Exception exception)
			{
				Logger.Instance.Fatal(exception);
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020CC File Offset: 0x000002CC
		private static void Run()
		{
			Agent.Instance.Init(Config.Instance);
			Starter.Instance.Init(Config.Instance);
			try
			{
				Program.RunSession();
			}
			finally
			{
				Agent.Instance.Dispose();
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x0000211C File Offset: 0x0000031C
		private static void RunSession()
		{
			Statistics.Instance.Init("563f6dee0d52d0dd7c1a7cc4b9df5626364d2d5b", "https://stats.walliant.com");
			Statistics.Instance.BeginSession();
			try
			{
				Program.RunApplication();
			}
			finally
			{
				Statistics.Instance.EndSession();
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000216C File Offset: 0x0000036C
		private static void RunApplication()
		{
			using (new Updater("walliant", new Uri("https://update.walliant.com")))
			{
				Program.Configure();
				Form form = Program.CreateForm();
				MessageFilter messageFilter = new MessageFilter(WindowsMessage.Close);
				messageFilter.Filtered += delegate(object sender, EventArgs e)
				{
					form.Close();
				};
				Application.AddMessageFilter(messageFilter);
				Application.Run(form);
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000021EC File Offset: 0x000003EC
		private static void Configure()
		{
			ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
			AppDomain.CurrentDomain.UnhandledException += Program.OnDomainException;
			Application.ThreadException += Program.OnApplicationException;
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x0000223B File Offset: 0x0000043B
		private static void OnDomainException(object sender, UnhandledExceptionEventArgs e)
		{
			Logger.Instance.Fatal((Exception)e.ExceptionObject);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002252 File Offset: 0x00000452
		private static void OnApplicationException(object sender, ThreadExceptionEventArgs e)
		{
			Logger.Instance.Fatal(e.Exception);
			Application.Exit();
		}

		// Token: 0x0600000A RID: 10 RVA: 0x0000226C File Offset: 0x0000046C
		private static Form CreateForm()
		{
			IChanger changer2;
			if (!Host.Modern)
			{
				IChanger changer = new Gh.Walliant.Wallpaper.Impl.Changers.Legacy.Changer();
				changer2 = changer;
			}
			else
			{
				IChanger changer = new Gh.Walliant.Wallpaper.Impl.Changers.Modern.Changer();
				changer2 = changer;
			}
			Factory factory = new Factory();
			return new MainForm(changer2, factory);
		}
	}
}
