using CIS174GameProject.ErrorReport;
using CIS174GameProject.Models;
using CIS174GameProject.Shared.Orchestrators.Interfaces;
using CIS174GameProject.Shared.ViewModels;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace CIS174GameProject.Controllers
{
    [ExceptionHandler]
    public class ErrorController : Controller
    {
        private readonly IErrorOrchestrator _errorOrchestrator;

        public ErrorController(IErrorOrchestrator errorOrchestrator)
        {
            _errorOrchestrator = errorOrchestrator;
        }

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

        public void CauseError()
        {
            _errorOrchestrator.CauseError();
        }
    }
}
