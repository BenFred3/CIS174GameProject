using CIS174GameProject.Shared.Orchestrators;
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
        public List<HighScoreViewModel> GetTopTenHighscores()
        {
            var highscores = _highScoreOrchestrator.GetTopTenHighscores();

            return highscores;
        }

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

        public async Task<string> CreateHighscore(Guid personID, string email, decimal newHighscore)
        {
            var updatedChanges = await _highScoreOrchestrator.CreateHighscore(new HighScoreViewModel
            {
                HighscoreId = Guid.NewGuid(),
                PersonId = personID,
                Email = email,
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

        [HttpPost]
        public async Task<string> UpdateHighscore(string email, string newHighscore)
        {
            decimal newHighscoreDecimal = decimal.Parse(newHighscore);

            PersonOrchestrator pO = new PersonOrchestrator();
            List<PersonViewModel> currentPeopleInDatabase = await pO.GetAllPeople();
            PersonViewModel currentPerson = currentPeopleInDatabase.Find(x => x.Email.Equals(email));

            List<HighScoreViewModel> currentHighscores = GetAllHighscores();
            HighScoreViewModel inDatabase = currentHighscores.Find(x => x.PersonId.Equals(currentPerson.PersonId));

            if (inDatabase == null || inDatabase.PersonId == Guid.Empty)
            {
                var result = await CreateHighscore(currentPerson.PersonId, email, newHighscoreDecimal);
                return result;
            }
            else if (inDatabase.Email == email)
            {
                var result = await _highScoreOrchestrator.UpdateHighscore(new HighScoreViewModel
                {
                    HighscoreId = inDatabase.HighscoreId,
                    PersonId = inDatabase.PersonId,
                    Email = email,
                    Score = newHighscoreDecimal,
                    DateAttained = DateTime.Now
                });

                return result;
            }
            else
            {
                var result = await CreateHighscore(inDatabase.PersonId, email, newHighscoreDecimal);
                return result;
            }
        }

        public async Task<HighScoreViewModel> GetHighscore(Guid personId)
        {
            var highscore = await _highScoreOrchestrator.GetHighscore(personId);

            var highscoreModel = new HighScoreViewModel
            {
                HighscoreId = highscore.HighscoreId,
                PersonId = highscore.PersonId,
                Email = highscore.Email,
                Score = highscore.Score,
                DateAttained = DateTime.Now
            };

            return highscoreModel;
        }
    }
}
