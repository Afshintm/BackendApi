using IdentityServer3.Core.Configuration;
using IdentityServer.Host.Configuration.Config;
using Owin;
using Serilog;

namespace IdentityServer.Host.Web
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
            //Log.Logger = new LoggerConfiguration()
            //    .MinimumLevel.Debug()
            //    .WriteTo.Trace()
            //    .CreateLogger();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Trace(outputTemplate: "{Timestamp} [{Level}] ({Name}){NewLine} {Message}{NewLine}{Exception}")
                .MinimumLevel.Debug()
                .CreateLogger();

			app.UseIdentityServer();
            //app.UseCors(CorsOptions.AllowAll);

            //var factory = new IdentityServerServiceFactory()
            //            .UseInMemoryUsers(Users.Get())
            //            .UseInMemoryClients(Clients.Get())
            //            .UseInMemoryScopes(Scopes.Get());

            //var options = new IdentityServerOptions
            //{
            //    SigningCertificate = Certificate.Load(),
            //    Factory = factory,
            //};

            //app.Map("/core", idsrvApp =>
            //{
            //    idsrvApp.UseIdentityServer(options);
            //});



        }
	}
}