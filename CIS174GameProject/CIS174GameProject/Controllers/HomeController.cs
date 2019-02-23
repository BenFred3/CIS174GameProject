using CIS174GameProject.Shared.Orchestrators;
using CIS174GameProject.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIS174GameProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        protected override async void OnException(ExceptionContext ex)
        {
            ex.ExceptionHandled = true;

            ErrorOrchestrator eo = new ErrorOrchestrator();
            ErrorViewModel errorViewModel = new ErrorViewModel
            {
                ErrorId = Guid.NewGuid(),
                ErrorDate = DateTime.Now,
                StackTrace = ex.Exception.StackTrace,
                ErrorMessage = ex.Exception.Message
            };
            if (ex.Exception.InnerException is null)
            {
                errorViewModel.InnerExceptions = "None";
            }
            else
            {
                errorViewModel.InnerExceptions = ex.Exception.InnerException.ToString();
            }
            await eo.CreateErrorLog(errorViewModel);

            ex.Result = RedirectToAction("Error", "Error");
        }
    }
}