using CIS174GameProject.Domain;
using CIS174GameProject.Shared.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CIS174GameProject.Shared.Orchestrators
{
    public class PersonOrchestrator
    {
        private readonly ProjectContext _projectContext;

        public PersonOrchestrator()
        {
            _projectContext = new ProjectContext();
        }

        public List<PersonViewModel> GetAllPeople()
        {
            var people = _projectContext.People.Select(x => new PersonViewModel
            {
                PersonName = x.FirstName + " " + x.LastName,
                DateCreated = x.DateCreated,
                Email = x.Email
            }).ToList();

            return people;
        }
    }
}
