using CIS174GameProject.Domain;
using CIS174GameProject.Shared.Orchestrators.Interfaces;
using CIS174GameProject.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS174GameProject.Shared.Orchestrators
{
    public class ProjectMembersOrchestrator : IProjectMembersOrchestrator
    {
        private readonly ProjectContext _projectContext;

        public ProjectMembersOrchestrator()
        {
            _projectContext = new ProjectContext();
        }

        public List<ProjectMembersViewModel> GetAllProjectMembers()
        {
            var Ben = new ProjectMembersViewModel
            {
                Name = "Ben Frederickson",
                Email = "bfrederickson@dmacc.edu",
                Role = "Work Flow Manager"
            };

            var Jared = new ProjectMembersViewModel
            {
                Name = "Jared Holliday",
                Email = "jrholliday@dmacc.edu",
                Role = "Repo Master"
            };

            var Ian = new ProjectMembersViewModel
            {
                Name = "Ian Tibe",
                Email = "imtibe@dmacc.edu",
                Role = "Unity Manager / Tester"
            };

            List<ProjectMembersViewModel> members = new List<ProjectMembersViewModel>()
            {
                Jared,
                Ben,
                Ian
            };

            return members;
        }
    }
}
