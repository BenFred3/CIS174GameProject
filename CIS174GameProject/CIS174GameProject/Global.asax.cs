using System;
using System.Collections.Generic;
using System.Linq;
using CIS174GameProject.Shared.Orchestrators;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CIS174GameProject.Shared.ViewModels;
using System.Threading.Tasks;
using CIS174GameProject.Controllers;

namespace CIS174GameProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var lastError = Server.GetLastError();
            var code = (lastError is HttpException) ? (lastError as HttpException).GetHttpCode() : 500;

            if (code == 404)
            {
                Response.Redirect("/Error/NotFound");
            }
            else
            {
                Response.Redirect("/Error/Error");
            }
        }
    }
}
