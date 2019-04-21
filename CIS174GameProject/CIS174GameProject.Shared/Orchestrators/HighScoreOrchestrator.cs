using CIS174GameProject.Domain;
using CIS174GameProject.Domain.Entities;
using CIS174GameProject.Shared.Orchestrators.Interfaces;
using CIS174GameProject.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174GameProject.Shared.Orchestrators
{
    public class HighScoreOrchestrator : IHighScoreOrchestrator
    {
        private readonly ProjectContext _projectContext;

        public HighScoreOrchestrator()
        {
            _projectContext = new ProjectContext();
        }

        public List<HighScoreViewModel> GetAllHighscores()
        {
            var highscores = _projectContext.Highscores.Select(x => new HighScoreViewModel
            {
                HighscoreId = x.HighscoreId,
                PersonId = x.PersonId,
                Email = x.Email,
                Score = x.Score,
                DateAttained = x.DateAttained
            }).ToList();

            return highscores;
        }

        public List<HighScoreViewModel> GetHighscoresSorted()
        {
            var highscores = _projectContext.Highscores.Select(x => new HighScoreViewModel
            {
                HighscoreId = x.HighscoreId,
                PersonId = x.PersonId,
                Email = x.Email,
                Score = x.Score,
                DateAttained = x.DateAttained
            }).ToList();

            var SortedList = highscores.OrderBy(x => x.Score).ToList();

            return SortedList;
        }

        public List<HighScoreViewModel> GetTopTenHighscores()
        {
            var highscores = _projectContext.Highscores.Select(x => new HighScoreViewModel
            {
                HighscoreId = x.HighscoreId,
                PersonId = x.PersonId,
                Email = x.Email,
                Score = x.Score,
                DateAttained = x.DateAttained
            }).ToList();

            var SortedList = highscores.OrderBy(x => x.Score).ToList();

            SortedList.Reverse();

            var listAmount = SortedList.Count;
            var TopTenList = new List<HighScoreViewModel>();

            for (var i = 0; i < listAmount; i++)
            {
                TopTenList.Insert(i, SortedList.First());
                SortedList.RemoveAt(0);
            }
            SortedList.Clear();

            return TopTenList;
        }

        public async Task<int> CreateHighscore(HighScoreViewModel newHighscore)
        {
            _projectContext.Highscores.Add(new HighScore
            {
                HighscoreId = Guid.NewGuid(),
                PersonId = newHighscore.PersonId,
                Email = newHighscore.Email,
                Score = newHighscore.Score,
                DateAttained = newHighscore.DateAttained
            });
            
            return await _projectContext.SaveChangesAsync();
        }

        public async Task<string> UpdateHighscore(HighScoreViewModel newHighscore)
        {
            var highscores = _projectContext.Highscores.ToList();

            var updateHighscore = await _projectContext.Highscores.FindAsync(newHighscore.HighscoreId);

            if (updateHighscore == null)
            {
                return "Error while updating.";
            }
            
            if (updateHighscore.Score > newHighscore.Score)
            {
                return "Score was too low. Cannot replace highscore.";
            }
            if(updateHighscore.Score == newHighscore.Score)
            {
                return "The score is the same.";
            }

            updateHighscore.Score = newHighscore.Score;
            updateHighscore.Email = newHighscore.Email;
            updateHighscore.DateAttained = newHighscore.DateAttained;

            await _projectContext.SaveChangesAsync();

            return "Succesfully Updated.";
        }

        public async Task<HighScore> GetHighscore(Guid personId)
        {
            var highscore = await _projectContext.Highscores.FindAsync(personId);

            if (highscore == null)
            {
                return new HighScore() { HighscoreId = Guid.Empty, PersonId = personId, Email = "Default@Email.com", Score = 0m, DateAttained = DateTime.Now };
            }
            else
            {
                return highscore;
            }
        }
    }
}
