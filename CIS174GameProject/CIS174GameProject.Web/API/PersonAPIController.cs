using CIS174GameProject.Shared.Orchestrators;
using CIS174GameProject.Shared.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace CIS174GameProject.API
{
    [Route("api/v1/person")]
    public class PersonAPIController : ApiController
    {
        private readonly PersonOrchestrator _personOrchestrator;

        public PersonAPIController()
        {
            _personOrchestrator = new PersonOrchestrator();
        }

        [HttpGet]
        public List<PersonViewModel> GetAllPeople()
        {
            var people = _personOrchestrator.GetAllPeople();

            return people;
        }
    }
}
