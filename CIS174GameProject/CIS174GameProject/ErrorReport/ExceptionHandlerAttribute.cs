using CIS174GameProject.Domain;
using CIS174GameProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIS174GameProject.ErrorReport
{
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