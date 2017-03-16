using System.Web.Http;
using AttributeRouting.Web.Http.WebHost;
using WebApiBackend.Controllers;

[assembly: WebActivator.PreApplicationStartMethod(typeof(WebApiBackend.AttributeRoutingHttpConfig), "Start")]

namespace WebApiBackend 
{
    public static class AttributeRoutingHttpConfig
	{
		public static void RegisterRoutes(HttpRouteCollection routes) 
		{    
			// See http://github.com/mccalltd/AttributeRouting/wiki for more options.
			// To debug routes locally using the built in ASP.NET development server, go to /routes.axd

            //routes.MapHttpAttributeRoutes();
            routes.MapHttpAttributeRoutes(cfg =>
            {
                cfg.InMemory = true;
                cfg.AutoGenerateRouteNames = true;
                cfg.AddRoutesFromAssemblyOf<ItemController>();
            });
		}

        public static void Start() 
		{
            RegisterRoutes(GlobalConfiguration.Configuration.Routes);
        }
    }
}
