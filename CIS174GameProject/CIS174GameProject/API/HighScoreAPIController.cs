using CIS174GameProject.Shared.Orchestrators.Interfaces;
using CIS174GameProject.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace CIS174GameProject.API
{
    [Route("api/v1/highscores")]
    public class HighScoreAPIController : ApiController
    {
        private readonly IHighScoreOrchestrator _highScoreOrchestrator;

        public HighScoreAPIController(IHighScoreOrchestrator highScoreOrchestrator)
        {
            _highScoreOrchestrator = highScoreOrchestrator;
        }
        
        [HttpGet]
        [Route("api/v1/highscores/get")]
        public List<HighScoreViewModel> GetAllHighscores()
        {
            var highscores = _highScoreOrchestrator.GetAllHighscores();

            return highscores;
        }

        public List<HighScoreViewModel> GetHighscoresSorted()
        {
            var highscores = _highScoreOrchestrator.GetHighscoresSorted();

            return highscores;
        }

        public List<HighScoreViewModel> GetTopFiveHighscores()
        {
            var highscores = _highScoreOrchestrator.GetTopFiveHighscores();

            return highscores;
        }

        public async Task<string> CreateHighscore(Guid personID, decimal newHighscore)
        {
            var updatedChanges = await _highScoreOrchestrator.CreateHighscore(new HighScoreViewModel
            {
                PersonId = personID,
                Score = newHighscore,
                DateAttained = DateTime.Now
            });

            if (updatedChanges == 0)
            {
                return "Nothing was created.";
            }
            else if (updatedChanges == 1)
            {
                return "Highscore was created.";
            }
            else
            {
                return "Error has occured";
            }
        }

        public async Task<string> UpdateHighscore(Guid personID, decimal newHighscore)
        {
            List<HighScoreViewModel> currentHighscores = GetAllHighscores();
            
            HighScoreViewModel inDatabase = currentHighscores.Find(x => x.PersonId.Equals(personID));

            if (inDatabase.PersonId == personID && inDatabase.Score == newHighscore)
            {
                var result = await _highScoreOrchestrator.UpdateHighscore(new HighScoreViewModel
                {
                    PersonId = personID,
                    Score = newHighscore,
                    DateAttained = DateTime.Now
                });

                return result;
            }
            else
            {
                return await CreateHighscore(personID, newHighscore);
            }
        }

        public async Task<HighScoreViewModel> GetHighscore(Guid personId)
        {
            var highscore = await _highScoreOrchestrator.GetHighscore(personId);

            var highscoreModel = new HighScoreViewModel
            {
                PersonId = highscore.PersonId,
                Score = highscore.Score,
                DateAttained = DateTime.Now
            };

            return highscoreModel;
        }
    }
}
