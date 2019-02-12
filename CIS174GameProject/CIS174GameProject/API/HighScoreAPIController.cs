using CIS174GameProject.Shared.Orchestrators;
using CIS174GameProject.Shared.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace CIS174GameProject.API
{
    [Route("api/v1/highscore")]
    public class HighScoreAPIController : ApiController
    {
        private readonly HighScoreOrchestrator _highScoreOrchestrator;

        public HighScoreAPIController()
        {
            _highScoreOrchestrator = new HighScoreOrchestrator();
        }

        [HttpGet]
        public List<HighScoreViewModel> GetAllPeople()
        {
            var highscores = _highScoreOrchestrator.GetAllHighScores();

            return highscores;
        }
    }
}
