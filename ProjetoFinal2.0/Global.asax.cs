using ProjetoFinal2._0.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProjetoFinal2._0
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            CheckRolesAndSuperUser();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        private void CheckRolesAndSuperUser()
        {
            UserHelper.UsersHelper.CheckRole("Admin");
            UserHelper.UsersHelper.CheckRole("User");
            UserHelper.UsersHelper.CheckRole("Customer");
            UserHelper.UsersHelper.CheckRole("Provider");
            UserHelper.UsersHelper.CheckSuperUser();
        }
    }
}
