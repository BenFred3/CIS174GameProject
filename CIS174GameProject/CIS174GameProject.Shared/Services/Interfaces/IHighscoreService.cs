using CIS174GameProject.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS174GameProject.Shared.Services.Interfaces
{
    interface IHighscoreService
    {
        List<HighScoreViewModel> CreateDataThree();
        List<HighScoreViewModel> CreateDataSix();
        HighScoreViewModel CreateHS(Guid PersonIdHS, decimal ScoreHS);
        String CreateHighscore(Guid personId, decimal newHighScore);
        int CreateHighscore();
        string UpdateHighscore(Guid personId, decimal newHighscore, HighScoreViewModel previousViewModel);
        string UpdateHighscore(HighScoreViewModel newHighscore, HighScoreViewModel previousViewModel);
        List<HighScoreViewModel> GetAllHighscores();
        List<HighScoreViewModel> GetHighscoresSorted();
        List<HighScoreViewModel> GetTopFiveHighscores();
        List<HighScoreViewModel> SortHighscores(List<HighScoreViewModel> HSList);
    }
}
