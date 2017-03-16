using BusinessServices;
using DataModel;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApiBackend.App_Start;
using WebApiBackend.Controllers;

namespace WebApiBackend
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start ()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();

            
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var unity = new UnityContainer();

            unity.RegisterType<ItemController>();

            unity.RegisterType<IItemServices, ItemServices>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());  

            GlobalConfiguration.Configuration.DependencyResolver = new IoCContainer(unity);

        }
    }
}
