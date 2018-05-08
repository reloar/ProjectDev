using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TemplateMVC.App_Start;

namespace TemplateMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           // AreaRegistration.RegisterAllAreas();
           //// RouteConfig.RegisterRoutes(RouteTable.Routes);
           FilterConfig.Configure(GlobalFilters.Filters);
        }
    }
}
