using Owin;
using Serilog;

namespace IdentityServer.Host.Web
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.WriteTo.Trace()
				.CreateLogger();

			app.UseIdentityServer();
		}
	}
}