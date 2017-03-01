using Microsoft.Owin;
using Owin;
using System.Web.Http;
using IdentityServer3.AccessTokenValidation;
using System.Web.Http.OData.Extensions;
using Ioc.Core.Infrastructure;
using Autofac.Integration.WebApi;
using System.IdentityModel.Tokens;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(ProductsApi.Startup))]

namespace ProductsApi
{
    public class Startup
    {
        private static HttpConfiguration _config;
        public static HttpConfiguration Config { get {
            if (_config == null) _config = new HttpConfiguration();
            return _config;
        }
            set { _config = value; }
        }
        public void Configuration(IAppBuilder app)
        {
            // accept access tokens from identityserver and require a scope of 'api1'
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://localhost:44302/core",
                //Authority = "https://IdentityServer3.com/core",
                //Authority = "https://idserver3.azurewebsites.net/core",
                ClientId = "clientcredentials.client",
				ClientSecret = "secret",
                RequiredScopes = new[] { "write" },
                DelayLoadMetadata = true
            });

			//http://docs.autofac.org/en/latest/integration/webapi.html#owin-integration
            // STANDARD WEB API SETUP:

            // Get your HttpConfiguration. In OWIN, you'll create one
            // rather than using GlobalConfiguration.Here getting result of calling Register method of WebApiConfig
            WebApiConfig.Register(Config);

            //AreaRegistration.RegisterAllAreas();

            // Register your Web API controllers.

            // Run other optional steps, like registering filters,
            // per-controller-type services, etc., then set the dependency resolver
            // to be Autofac.
            EngineContext.Initialize(false);

            //set dependency resolver for webApi
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(EngineContext.Current.ContainerManager.Container);

            // OWIN WEB API SETUP:

            // Register the Autofac middleware FIRST, then the Autofac Web API middleware,
            // and finally the standard Web API middleware.
            app.UseAutofacMiddleware(EngineContext.Current.ContainerManager.Container);
            app.UseAutofacWebApi(Config);
            app.UseWebApi(Config);

        }
    }
}