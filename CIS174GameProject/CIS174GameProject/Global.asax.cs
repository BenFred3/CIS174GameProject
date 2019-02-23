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

        async void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            if (ex != null)
            {
                await LogError(ex);

                Server.Transfer("~/Error/Error", true);
            }
        }

        public async Task LogError(Exception ex)
        {
            ErrorOrchestrator eo = new ErrorOrchestrator();
            ErrorViewModel newErrorViewModel = new ErrorViewModel();

            newErrorViewModel.ErrorId = Guid.NewGuid();
            newErrorViewModel.ErrorDate = DateTime.Now;
            newErrorViewModel.StackTrace = ex.StackTrace;
            newErrorViewModel.ErrorMessage = ex.Message;

            await eo.CreateErrorLog(newErrorViewModel);
        }
    }
}
