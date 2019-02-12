using CIS174GameProject.Domain;
using CIS174GameProject.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS174GameProject.Shared.Orchestrators
{
    public class ProjectMembersOrchestrator
    {
        private readonly ProjectContext _projectContext;

        public ProjectMembersOrchestrator()
        {
            _projectContext = new ProjectContext();
        }

        public string GetAllProjectMembers()
        {
            string projectMembers;

            projectMembers = "Name: Benjamin Frederickson\nEmail: bfrederickson @dmacc.edu\nRole: Work-flow Manager, Programmer"
                + " Name: Jared Holliday\nEmail: jrholliday @dmacc.edu\nRole: Repo Manager, Programmer"
                + " Name: Ian Tibe\nEmail: imtibe @dmacc.edu\nRole: Test Builds / Managing Unity, Programmer";

            return projectMembers;
        }
    }
}
