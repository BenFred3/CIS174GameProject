using CIS174GameProject.Shared.Orchestrators.Interfaces;
using CIS174GameProject.Shared.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace CIS174GameProject.API
{
    [Route("api/v1/members")]
    public class ProjectMembersAPIController : ApiController
    {
        private readonly IProjectMembersOrchestrator _projectMembersOrchestrator;

        public ProjectMembersAPIController(IProjectMembersOrchestrator projectMembersOrchestrator)
        {
            _projectMembersOrchestrator = projectMembersOrchestrator;
        }

        [HttpGet]
        public List<ProjectMembersViewModel> GetProjectMembers()
        {
            var projectMembers = _projectMembersOrchestrator.GetAllProjectMembers();

            return projectMembers;
        }
    }
}