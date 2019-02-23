using CIS174GameProject.Domain;
using CIS174GameProject.Domain.Entities;
using CIS174GameProject.Shared.ViewModels;
using System;
using System.Threading.Tasks;

namespace CIS174GameProject.Shared.Orchestrators
{
    public class ErrorOrchestrator 
    {
        private readonly ProjectContext _projectContext;

        public ErrorOrchestrator()
        {
            _projectContext = new ProjectContext();
        }

        public async Task<int> CreateErrorLog(ErrorViewModel error)
        {
            _projectContext.Errors.Add(new Error
            {
                ErrorId = error.ErrorId,
                ErrorDate = DateTime.Now,
                ErrorMessage = error.ErrorMessage,
                StackTrace = error.StackTrace,
                InnerExceptions = error.InnerExceptions
            });

            return await _projectContext.SaveChangesAsync();
        }

        public async Task<ErrorViewModel> CauseError()
        {
            try
            {
                throw new OutOfMemoryException();
            }
            catch (OutOfMemoryException ex)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel();

                errorViewModel.ErrorId = Guid.NewGuid();
                errorViewModel.ErrorDate = DateTime.Now;
                errorViewModel.StackTrace = ex.StackTrace;
                errorViewModel.ErrorMessage = ex.Message;
                if (ex.InnerException is null)
                {
                    errorViewModel.InnerExceptions = "None";
                }
                else
                { 
                    errorViewModel.InnerExceptions = ex.InnerException.ToString();
                }
                await CreateErrorLog(errorViewModel);

                return (errorViewModel);
            }
        }
    }
}
