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

        public void CauseError()
        {
            throw new OutOfMemoryException();
        }
    }
}
