using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace NerdDinner
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            ModelBinderProviders.BinderProviders.Add(new EFModelBinderProvider());

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            Application["Version"] = string.Format("{0}.{1}", version.Major, version.Minor);
        }
    }
}