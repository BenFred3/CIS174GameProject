using System;
using CIS174GameProject.Shared.Orchestrators;
using CIS174GameProject.Shared.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CIS174GameProject.API
{
    [Route("api/v1/members")]
    public class ProjectMembersAPIController : ApiController
    {
        private readonly ProjectMembersOrchestrator _projectMembersOrchestrator;

        public ProjectMembersAPIController()
        {
            _projectMembersOrchestrator = new ProjectMembersOrchestrator();
        }

        [HttpGet]
        public List<ProjectMembersViewModel> GetProjectMembers()
        {
            var projectMembers = _projectMembersOrchestrator.GetAllProjectMembers();

            return projectMembers;
        }
    }
}