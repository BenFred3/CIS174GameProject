using CIS174GameProject.Shared.Services.Interfaces;
using CIS174GameProject.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CIS174GameProject.Shared.Services
{
    public class HighscoreService : IHighscoreService
    {
        public List<HighScoreViewModel> CreateDataThree()
        {
            var Person1 = CreateHS(Guid.Parse("52fc5dd8-c147-4fbc-82e6-465fd09b01a3"), 1000.00m);
            var Person2 = CreateHS(Guid.Parse("2dfafb6c-6ce3-44e2-b41d-6bffcad912a9"), 500.00m);
            var Person3 = CreateHS(Guid.Parse("218d38cd-ecfc-43dd-b844-934f701af254"), 200.00m);

            List<HighScoreViewModel> HSList = new List<HighScoreViewModel> { Person1, Person2, Person3};

            var SortedList = HSList.OrderBy(x => x.Score).ToList();
            SortedList.Reverse();

            return SortedList;
        }

        public List<HighScoreViewModel> CreateDataSix()
        {
            var Person1 = CreateHS(Guid.Parse("52fc5dd8-c147-4fbc-82e6-465fd09b01a3"), 1000.00m);
            var Person2 = CreateHS(Guid.Parse("2dfafb6c-6ce3-44e2-b41d-6bffcad912a9"), 500.00m);
            var Person6 = CreateHS(Guid.Parse("218d78cd-ecfc-43dd-b844-934f701af254"), 300.00m);
            var Person3 = CreateHS(Guid.Parse("218d48cd-ecfc-43dd-b844-934f701af254"), 200.00m);
            var Person4 = CreateHS(Guid.Parse("218d58cd-ecfc-43dd-b844-934f701af254"), 100.00m);
            var Person5 = CreateHS(Guid.Parse("218d68cd-ecfc-43dd-b844-934f701af254"), 50.00m);

            List<HighScoreViewModel> HSList = new List<HighScoreViewModel> { Person1, Person2, Person3, Person4, Person5, Person6 };

            var SortedList = HSList.OrderBy(x => x.Score).ToList();
            SortedList.Reverse();

            return SortedList;
        }

        public HighScoreViewModel CreateHS(Guid PersonIdHS, decimal ScoreHS)
        {
            return new HighScoreViewModel
            {
                PersonId = PersonIdHS,
                Score = ScoreHS,
                DateAttained = DateTime.Now
            };
        }

        public string CreateHighscore(Guid personId, decimal newHighScore)
        {
            int returnedInformation = CreateHighscore();

            if (returnedInformation == 0)
            {
                return "Highscore was not created.";
            }
            else if (returnedInformation == 1)
            {
                return "Highscore was created.";
            }
            else
            {
                return "An error has occured.";
            }
        }

        public int CreateHighscore()
        {
            return 1;
        }

        public string UpdateHighscore(Guid personId, decimal newHighscore, HighScoreViewModel previousViewModel)
        {
            HighScoreViewModel newHighscoreModel = new HighScoreViewModel
            {
                PersonId = personId,
                Score = newHighscore,
                DateAttained = DateTime.Now
            };

            return UpdateHighscore(newHighscoreModel, previousViewModel);
        }

        public string UpdateHighscore(HighScoreViewModel newHighscore, HighScoreViewModel previousViewModel)
        {
            if (previousViewModel.Score > newHighscore.Score)
            {
                return "Score was too low. Cannot replace highscore.";
            }
            else
            {
                return "Succesfully Updated.";
            }
        }

        public List<HighScoreViewModel> GetAllHighscores()
        {
            List<HighScoreViewModel> HSList = CreateDataSix();

            return HSList;
        }

        public List<HighScoreViewModel> GetHighscoresSorted()
        {
            List<HighScoreViewModel> HSList = CreateDataSix();

            var SortedList = HSList.OrderBy(x => x.Score).ToList();
            SortedList.Reverse();

            return SortedList;
        }

        public List<HighScoreViewModel> GetTopFiveHighscores()
        {
            List<HighScoreViewModel> HSList = CreateDataSix();

            var SortedList = HSList.OrderBy(x => x.Score).ToList();
            SortedList.Reverse();

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

        public List<HighScoreViewModel> SortHighscores(List<HighScoreViewModel> HSList)
        {
            var SortedList = HSList.OrderBy(x => x.Score).ToList();
            SortedList.Reverse();

            return SortedList;
        }
    }
}
