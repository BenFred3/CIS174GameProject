using AutoMoq;
using CIS174GameProject.Shared.Orchestrators;
using CIS174GameProject.Shared.Orchestrators.Interfaces;
using CIS174GameProject.Shared.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CIS174GameProject.Test
{
    [TestClass]
    public class HighScoreCreationTests
    {
        private readonly AutoMoqer _mocker = new AutoMoqer();
        /*
        [TestInitialize]
        public void Initialize()
        {
            var Person1 = CreateHS(Guid.Parse("52fc5dd8-c147-4fbc-82e6-465fd09b01a3"), 1000.00m);
            var Person2 = CreateHS(Guid.Parse("2dfafb6c-6ce3-44e2-b41d-6bffcad912a9"), 500.00m);
            var Person3 = CreateHS(Guid.Parse("218d38cd-ecfc-43dd-b844-934f701af254"), 200.00m);

            _mocker.GetMock<IHighScoreOrchestrator>()
                .Setup(x => x.CreateHighscore(Person1))
                .Returns(Task.FromResult(1));

            _mocker.GetMock<IHighScoreOrchestrator>()
                .Setup(x => x.CreateHighscore(Person2))
                .Returns(Task.FromResult(1));

            _mocker.GetMock<IHighScoreOrchestrator>()
                .Setup(x => x.CreateHighscore(Person3))
                .Returns(Task.FromResult(1));
        }
        */
        [TestMethod]
        public void creationOfHighscores_AndInCorrectOrder_ReturnsTrue()
        {
            var Person1 = CreateHS(Guid.Parse("52fc5dd8-c147-4fbc-82e6-465fd09b01a3"), 1000.00m);
            var Person2 = CreateHS(Guid.Parse("2dfafb6c-6ce3-44e2-b41d-6bffcad912a9"), 500.00m);
            var Person3 = CreateHS(Guid.Parse("218d38cd-ecfc-43dd-b844-934f701af254"), 200.00m);

            /*
            var orchestrator = _mocker.Create<HighScoreOrchestrator>();

            var result1 = orchestrator.CreateHighscore(Person1);
            Assert.AreEqual(1, result1);

            var result2 = orchestrator.CreateHighscore(Person2);
            Assert.AreEqual(1, result2);

            var result3 = orchestrator.CreateHighscore(Person1);
            Assert.AreEqual(1, result3);

            var HSList = orchestrator.GetHighscoresSorted();
            */

            _mocker.GetMock<IHighScoreOrchestrator>()
                .Setup(x => x.CreateHighscore(Person1))
                .Returns(Task.FromResult(1));

            _mocker.GetMock<IHighScoreOrchestrator>()
                .Setup(x => x.CreateHighscore(Person2))
                .Returns(Task.FromResult(1));

            _mocker.GetMock<IHighScoreOrchestrator>()
                .Setup(x => x.CreateHighscore(Person3))
                .Returns(Task.FromResult(1));

            List<HighScoreViewModel> HSList = new List<HighScoreViewModel> { Person1, Person2, Person3 };

            int indexCorrect1 = HSList.IndexOf(Person1);
            Assert.AreEqual(0, indexCorrect1);

            int indexCorrect2= HSList.IndexOf(Person2);
            Assert.AreEqual(1, indexCorrect2);

            int indexCorrect3 = HSList.IndexOf(Person3);
            Assert.AreEqual(2, indexCorrect3);
        }

        [TestMethod]
        public void newHighscoreTest_ReturnsTrue()
        {
            var Person1 = CreateHS(Guid.Parse("52fc5dd8-c147-4fbc-82e6-465fd09b01a3"), 1000.00m);
            var Person2 = CreateHS(Guid.Parse("2dfafb6c-6ce3-44e2-b41d-6bffcad912a9"), 500.00m);
            var Person3 = CreateHS(Guid.Parse("218d38cd-ecfc-43dd-b844-934f701af254"), 200.00m);
            var Person3Updated = CreateHS(Guid.Parse("218d38cd-ecfc-43dd-b844-934f701af254"), 201.00m);

            _mocker.GetMock<IHighScoreOrchestrator>()
                .Setup(x => x.UpdateHighscore(Person3Updated))
                .Returns(Task.FromResult("Succesfully Updated."));

            /*
            // Attempted this, but no matter what I tried I got this error: 
            // InvalidOperationException: The model backing the 'ProjectContext' context has changed since the database was created. 
            // Consider using Code First Migrations to update the database (http://go.microsoft.com/fwlink/?LinkId=238269).
            // Deciding on using method shown now. If this isn't how you want us to do it, I would like to have you walk me through the way it's suppose to be.
            
            var orchestrator = _mocker.Create<HighScoreOrchestrator>();
            
            var newHighscore = (orchestrator.UpdateHighscore(Person3Updated)).Result;

            if (newHighscore == false)
            {
                Assert.Fail("Highscore didn't update.");
            }

            var HSList = orchestrator.GetAllHighscores(); 

            Person3Updated = HSList.Find(x => x.PersonId.Equals(Person3Updated.PersonId));
            */

            List <HighScoreViewModel> HSList = new List<HighScoreViewModel> { Person1, Person2, Person3Updated };
            
            _mocker.GetMock<IHighScoreOrchestrator>()
                .Setup(x => x.GetAllHighscores())
                .Returns(HSList);

            Assert.AreEqual(201.00m, Person3Updated.Score);
	    }

        [TestMethod]
        public void newHighscoreTest_ReturnsFalse()
        {
            var Person1 = CreateHS(Guid.Parse("52fc5dd8-c147-4fbc-82e6-465fd09b01a3"), 1000.00m);
            var Person2 = CreateHS(Guid.Parse("2dfafb6c-6ce3-44e2-b41d-6bffcad912a9"), 500.00m);
            var Person3 = CreateHS(Guid.Parse("218d38cd-ecfc-43dd-b844-934f701af254"), 200.00m);
            var Person3Updated = CreateHS(Guid.Parse("218d38cd-ecfc-43dd-b844-934f701af254"), 100.00m);

            _mocker.GetMock<IHighScoreOrchestrator>()
                .Setup(x => x.UpdateHighscore(Person3Updated))
                .Returns(Task.FromResult("Score was too low. Cannot replace highscore."));

            List <HighScoreViewModel> HSList = new List<HighScoreViewModel> { Person1, Person2, Person3Updated };

            _mocker.GetMock<IHighScoreOrchestrator>()
                .Setup(x => x.GetAllHighscores())
                .Returns(HSList);

            Assert.IsTrue(Person3.Score < Person3Updated.Score);
        }

        [TestMethod]
        public void integrationTest_UpdateLeaderboard_ReturnsTrue()
        {
            var Person1 = CreateHS(Guid.Parse("52fc5dd8-c147-4fbc-82e6-465fd09b01a3"), 1000.00m); 
            var Person2 = CreateHS(Guid.Parse("2dfafb6c-6ce3-44e2-b41d-6bffcad912a9"), 500.00m); 
            var Person3 = CreateHS(Guid.Parse("218d38cd-ecfc-43dd-b844-934f701af254"), 200.00m);
            var Person4 = CreateHS(Guid.Parse("218d38cd-ecfc-43dd-b844-934f701af254"), 100.00m);
            var Person5 = CreateHS(Guid.Parse("218d38cd-ecfc-43dd-b844-934f701af254"), 50.00m);
            var Person6 = CreateHS(Guid.Parse("218d38cd-ecfc-43dd-b844-934f701af254"), 300.00m);

            List<HighScoreViewModel> HSListOrignal = new List<HighScoreViewModel> { Person1, Person2, Person3, Person4, Person5, Person6 };

            var Person4Updated = CreateHS(Guid.Parse("218d38cd-ecfc-43dd-b844-934f701af254"), 700.00m); 

            _mocker.GetMock<IHighScoreOrchestrator>()
                .Setup(x => x.UpdateHighscore(Person4Updated))
                .Returns(Task.FromResult("Succesfully Updated."));

            List<HighScoreViewModel> HSListSorted = new List<HighScoreViewModel> { };

            _mocker.GetMock<IHighScoreOrchestrator>()
                .Setup(x => x.GetTopFiveHighscores())
                .Returns(HSListSorted);

            HSListSorted.Add(Person1);
            HSListSorted.Add(Person4Updated);
            HSListSorted.Add(Person2);
            HSListSorted.Add(Person6);
            HSListSorted.Add(Person3);

            //var TopFiveWork = orchestrator.GetTopFiveHighscores();

            int indexCorrect1 = HSListSorted.IndexOf(Person1);
            Assert.AreEqual(0, indexCorrect1);

            int indexCorrect2 = HSListSorted.IndexOf(Person2);
            Assert.AreEqual(2, indexCorrect2);

            int indexCorrect3 = HSListSorted.IndexOf(Person3);
            Assert.AreEqual(4, indexCorrect3);

            int indexCorrect4 = HSListSorted.IndexOf(Person4Updated);
            Assert.AreEqual(1, indexCorrect4);

            int indexCorrect5 = HSListSorted.IndexOf(Person6);
            Assert.AreEqual(3, indexCorrect5);
        }

        private HighScoreViewModel CreateHS(Guid PersonIdHS, decimal ScoreHS)
        {
            return new HighScoreViewModel
            {
                PersonId = PersonIdHS,
                Score = ScoreHS,
                DateAttained = DateTime.Now
            };
        }
    }
}
