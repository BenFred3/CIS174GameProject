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
                error.InnerExceptions = "";
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
