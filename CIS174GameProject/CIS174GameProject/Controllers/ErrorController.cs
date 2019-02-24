using CIS174GameProject.Domain;
using CIS174GameProject.Domain.Entities;
using CIS174GameProject.Models;
using CIS174GameProject.Shared.Orchestrators;
using CIS174GameProject.Shared.ViewModels;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace CIS174GameProject.Controllers
{
    [ExceptionHandler]
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

        public void CauseError()
        {
            _errorOrchestrator.CauseError();
        }
    }

    public class ExceptionHandlerAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            string innerEx = "";

            if (filterContext.Exception.InnerException is null)
            {
                innerEx = "None";
            }
            else
            {
                innerEx = filterContext.Exception.InnerException.ToString();
            }

            if (!filterContext.ExceptionHandled)
            {
                Error logger = new Error();

                logger = new Error()
                {
                    ErrorMessage = filterContext.Exception.Message,
                    StackTrace = filterContext.Exception.StackTrace,
                    ErrorDate = DateTime.Now,
                    ErrorId = Guid.NewGuid(),
                    InnerExceptions = innerEx
                };

                ProjectContext pc = new ProjectContext();
                pc.Errors.Add(logger);
                pc.SaveChanges();

                filterContext.ExceptionHandled = true;

                filterContext.Result = new ViewResult { ViewName = "Error" };
            }
        }
    }
}
