﻿using CIS174GameProject.Domain;
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
                PersonId = x.PersonId,
                Score = x.Score,
                DateAttained = x.DateAttained
            }).ToList();

            return highscores;
        }

        public List<HighScoreViewModel> GetHighscoresSorted()
        {
            var highscores = _projectContext.Highscores.Select(x => new HighScoreViewModel
            {
                PersonId = x.PersonId,
                Score = x.Score,
                DateAttained = x.DateAttained
            }).ToList();

            var SortedList = highscores.OrderBy(x => x.Score).ToList();

            return SortedList;
        }

        public List<HighScoreViewModel> GetTopFiveHighscores()
        {
            var highscores = _projectContext.Highscores.Select(x => new HighScoreViewModel
            {
                PersonId = x.PersonId,
                Score = x.Score,
                DateAttained = x.DateAttained
            }).ToList();

            var SortedList = highscores.OrderBy(x => x.Score).ToList();

            var firstElement = SortedList.First();
            SortedList.RemoveAt(0);
            var secondElement = SortedList.First();
            SortedList.RemoveAt(0);
            var thirdElement = SortedList.First();
            SortedList.RemoveAt(0);
            var fourthElement = SortedList.First();
            SortedList.RemoveAt(0);
            var fifthElement = SortedList.First();
            SortedList.Clear();

            var TopFiveList = new List<HighScoreViewModel> { firstElement, secondElement, thirdElement, fourthElement, fifthElement };

            return TopFiveList;
        }

        public async Task<int> CreateHighscore(HighScoreViewModel newHighscore)
        {
            _projectContext.Highscores.Add(new HighScore
            {
                HighscoreId = Guid.NewGuid(),
                PersonId = newHighscore.PersonId,
                Score = newHighscore.Score,
                DateAttained = newHighscore.DateAttained
            });
            
            return await _projectContext.SaveChangesAsync();
        }

        public async Task<string> UpdateHighscore(HighScoreViewModel newHighscore)
        {
            var updateHighscore = await _projectContext.Highscores.FindAsync(newHighscore.PersonId);

            if (updateHighscore == null)
            {
                return "Error while updating.";
            }
            
            if (updateHighscore.Score > newHighscore.Score)
            {
                return "Score was too low. Cannot replace highscore.";
            }

            updateHighscore.HighscoreId = Guid.NewGuid();
            updateHighscore.Score = newHighscore.Score;
            updateHighscore.DateAttained = newHighscore.DateAttained;

            await _projectContext.SaveChangesAsync();

            return "Succesfully Updated.";
        }
    }
}
