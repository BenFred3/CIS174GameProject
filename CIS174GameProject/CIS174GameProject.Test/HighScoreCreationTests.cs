using AutoMoq;
using CIS174GameProject.Shared.Orchestrators.Interfaces;
using CIS174GameProject.Shared.Services;
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

        [TestMethod]
        public void creationOfHighscores_AndInCorrectOrder_ReturnsTrue()
        {
            // Create a controller to use methods from. This controller simulates what the database would do if given the commands.
            var controller = _mocker.Create<HighscoreService>();

            // Create three highscores and get the string of the result.
            var result1 = controller.CreateHighscore(Guid.Parse("52fc5dd8-c147-4fbc-82e6-465fd09b01a3"), 1000.00m);
            var result2 = controller.CreateHighscore(Guid.Parse("2dfafb6c-6ce3-44e2-b41d-6bffcad912a9"), 500.00m);
            var result3 = controller.CreateHighscore(Guid.Parse("218d38cd-ecfc-43dd-b844-934f701af254"), 200.00m);

            // This is expected string result.
            var expectedResults = "Highscore was created.";

            // Check if the results are equal.
            Assert.AreEqual(expectedResults, result1);
            Assert.AreEqual(expectedResults, result2);
            Assert.AreEqual(expectedResults, result3);

            // Create people here to make a list.
            var HSList = controller.CreateDataThree();
            
            // Find the model in the list of highscores, find the index, check if it's what it should be in a ordered list.
            var foundModel1 = HSList.Find(x => x.PersonId == Guid.Parse("52fc5dd8-c147-4fbc-82e6-465fd09b01a3"));
            var foundModelIndex1 = HSList.IndexOf(foundModel1);
            Assert.AreEqual(0, foundModelIndex1);

            // Find the model in the list of highscores, find the index, check if it's what it should be in a ordered list.
            var foundModel2 = HSList.Find(x => x.PersonId == Guid.Parse("2dfafb6c-6ce3-44e2-b41d-6bffcad912a9"));
            var foundModelIndex2 = HSList.IndexOf(foundModel2);
            Assert.AreEqual(1, foundModelIndex2);

            // Find the model in the list of highscores, find the index, check if it's what it should be in a ordered list.
            var foundModel3 = HSList.Find(x => x.PersonId == Guid.Parse("218d38cd-ecfc-43dd-b844-934f701af254"));
            var foundModelIndex3 = HSList.IndexOf(foundModel3);
            Assert.AreEqual(2, foundModelIndex3);
        }

        [TestMethod]
        public void newHighscoreTest_ReturnsSuccesfullyUpdated()
        {
            // Create a controller to use methods from. This controller simulates what the database would do if given the commands.
            var controller = _mocker.Create<HighscoreService>();

            // Create the data.
            var HSList = controller.CreateDataThree();

            // Find the person.
            var person3 = HSList.Find(x => x.PersonId == Guid.Parse("218d38cd-ecfc-43dd-b844-934f701af254"));

            // Update the highscore and set the result of the update to a var.
            // We have to also pass a previous model because we cannot create that functionality in these tests where in a database we could.
            var resultOfUpdate = controller.UpdateHighscore(Guid.Parse("218d38cd-ecfc-43dd-b844-934f701af254"), 201.00m, person3);

            // Expected result from the update.
            var expectedResultOfUpdate = "Succesfully Updated.";

            // Check if the right result was found.
            Assert.AreEqual(expectedResultOfUpdate, resultOfUpdate);
	    }

        [TestMethod]
        public void newHighscoreTest_ReturnsScoreTooLow()
        {
            // Create a controller to use methods from. This controller simulates what the database would do if given the commands.
            var controller = _mocker.Create<HighscoreService>();

            // Create the data.
            var HSList = controller.CreateDataThree();

            // Find the person.
            var person3 = HSList.Find(x => x.PersonId == Guid.Parse("218d38cd-ecfc-43dd-b844-934f701af254"));

            // Update the highscore and set the result of the update to a var.
            // We have to also pass a previous model because we cannot create that functionality in these tests where in a database we could.
            var resultOfUpdate = controller.UpdateHighscore(Guid.Parse("218d38cd-ecfc-43dd-b844-934f701af254"), 199.00m, person3);

            // Expected result from the update.
            var expectedResultOfUpdate = "Score was too low. Cannot replace highscore.";

            // Check if the right result was found.
            Assert.AreEqual(expectedResultOfUpdate, resultOfUpdate);
        }

        [TestMethod]
        public void integrationTest_UpdateLeaderboard_ReturnsTrue()
        {

            // Create a controller to use methods from. This controller simulates what the database would do if given the commands.
            var controller = _mocker.Create<HighscoreService>();

            // Create data.
            var HSList = controller.CreateDataSix();
            
            // Find the person.
            var person4 = HSList.Find(x => x.PersonId == Guid.Parse("218d58cd-ecfc-43dd-b844-934f701af254"));

            // Update the highscore and set the result of the update to a var.
            // We have to also pass a previous model because we cannot create that functionality in these tests where in a database we could.
            var resultOfUpdate = controller.UpdateHighscore(Guid.Parse("218d58cd-ecfc-43dd-b844-934f701af254"), 700.00m, person4);

            // Expected result from the update.
            var expectedResultOfUpdate = "Succesfully Updated.";

            // Check if the right result was found.
            Assert.AreEqual(expectedResultOfUpdate, resultOfUpdate);
            
            // Get the index of the previous person
            var indexChanged = HSList.IndexOf(person4);

            // Actually hard update it in the list (Database would do this).
            HSList[indexChanged] = new HighScoreViewModel
            {
                PersonId = Guid.Parse("218d58cd-ecfc-43dd-b844-934f701af254"),
                Score = 700.00m,
                DateAttained = DateTime.Now
            };

            // Resort the list.
            HSList = controller.SortHighscores(HSList);

            // Get all the people to verify their index number.
            var person1 = HSList.Find(x => x.PersonId == Guid.Parse("52fc5dd8-c147-4fbc-82e6-465fd09b01a3"));
            var person2 = HSList.Find(x => x.PersonId == Guid.Parse("2dfafb6c-6ce3-44e2-b41d-6bffcad912a9"));
            var person3 = HSList.Find(x => x.PersonId == Guid.Parse("218d48cd-ecfc-43dd-b844-934f701af254"));
            var person4Updated = HSList.Find(x => x.PersonId == Guid.Parse("218d58cd-ecfc-43dd-b844-934f701af254"));
            var person5 = HSList.Find(x => x.PersonId == Guid.Parse("218d68cd-ecfc-43dd-b844-934f701af254"));
            var person6 = HSList.Find(x => x.PersonId == Guid.Parse("218d78cd-ecfc-43dd-b844-934f701af254"));

            // Assert that all the highscores are correctly sorted.
            int indexCorrect1 = HSList.IndexOf(person1);
            Assert.AreEqual(0, indexCorrect1);

            int indexCorrect2 = HSList.IndexOf(person2);
            Assert.AreEqual(2, indexCorrect2);

            int indexCorrect3 = HSList.IndexOf(person3);
            Assert.AreEqual(4, indexCorrect3);

            int indexCorrect4 = HSList.IndexOf(person4Updated);
            Assert.AreEqual(1, indexCorrect4);

            int indexCorrect5 = HSList.IndexOf(person5);
            Assert.AreEqual(5, indexCorrect5);

            int indexCorrect6 = HSList.IndexOf(person6);
            Assert.AreEqual(3, indexCorrect6);
        }
    }
}
