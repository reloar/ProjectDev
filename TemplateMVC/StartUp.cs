using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TemplateMVC.App_Start;

namespace TemplateMVC
{
   public partial class StartUp
    {
        public static void Configuration(IAppBuilder app)
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.Configure(GlobalFilters.Filters);
            ConfigureAuth(app);
        }
    }
}