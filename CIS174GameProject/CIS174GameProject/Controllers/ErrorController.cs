using CIS174GameProject.Models;
using CIS174GameProject.Shared.Orchestrators;
using CIS174GameProject.Shared.ViewModels;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CIS174GameProject.Controllers
{
    public class ErrorController : Controller
    {
        private ErrorOrchestrator _errorOrchestrator = new ErrorOrchestrator();

        public ViewResult Error()
        {
            return View();
        }

        public ViewResult NotFound()
        {
            Response.StatusCode = 404;
            return View("NotFound");
        }

        public ActionResult ErrorGenerator()
        {
            return View();
        }

        public async Task<ActionResult> CreateErrorLog(ErrorModel error)
        {
            if (error.InnerExceptions == "" || error.InnerExceptions is null)
            {
                error.InnerExceptions = "None";
            }

            var createdErrorLog = await _errorOrchestrator.CreateErrorLog(new ErrorViewModel
            {
                ErrorId = Guid.NewGuid(),
                ErrorDate = DateTime.Now,
                ErrorMessage = error.ErrorMessage,
                StackTrace = error.StackTrace,
                InnerExceptions = error.InnerExceptions
            });

            return Json(createdErrorLog, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> CauseError()
        {
            ErrorViewModel errorViewModel = await _errorOrchestrator.CauseError();
            return View("Error");
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
