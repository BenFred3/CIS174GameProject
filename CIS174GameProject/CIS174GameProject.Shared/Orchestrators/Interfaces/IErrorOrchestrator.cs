using CIS174GameProject.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS174GameProject.Shared.Orchestrators.Interfaces
{
    public interface IErrorOrchestrator
    {
        Task<int> CreateErrorLog(ErrorViewModel error);
        void CauseError();
    }
}
