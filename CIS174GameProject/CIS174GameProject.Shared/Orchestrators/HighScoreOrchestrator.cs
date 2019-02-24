using CIS174GameProject.Domain;
using CIS174GameProject.Shared.Orchestrators.Interfaces;
using CIS174GameProject.Shared.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CIS174GameProject.Shared.Orchestrators
{
    public class HighScoreOrchestrator : IHighScoreOrchestrator
    {
        private readonly ProjectContext _projectContext;

        public HighScoreOrchestrator()
        {
            _projectContext = new ProjectContext();
        }

        public List<HighScoreViewModel> GetAllHighScores()
        {
            var highscores = _projectContext.Highscores.Select(x => new HighScoreViewModel
            {
                Score = x.Score,
                DateAttained = x.DateAttained
            }).ToList();

            return highscores;
        }
    }
}
