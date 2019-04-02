using CIS174GameProject.Shared.Orchestrators;
using CIS174GameProject.Shared.Orchestrators.Interfaces;
using CIS174GameProject.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace CIS174GameProject.API
{
    [Route("api/v1/people")]
    public class PersonAPIController : ApiController
    {
        private readonly IPersonOrchestrator _personOrchestrator;

        public PersonAPIController(IPersonOrchestrator personOrchestrator)
        {
            _personOrchestrator = personOrchestrator;
        }

        [HttpGet]
        [Route("api/v1/people/get")]
        public Task<List<PersonViewModel>> GetAllPeople()
        {
            var people = _personOrchestrator.GetAllPeople();

            return people;
        }
    }
}
