using CIS174GameProject.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS174GameProject.Shared.Orchestrators.Interfaces
{
    public interface IHighScoreOrchestrator
    {
        List<HighScoreViewModel> GetAllHighscores();
        List<HighScoreViewModel> GetHighscoresSorted();
        List<HighScoreViewModel> GetTopFiveHighscores();
        Task<int> CreateHighscore(HighScoreViewModel newHighscore);
        Task<string> UpdateHighscore(HighScoreViewModel newHighscore);
    }
}
