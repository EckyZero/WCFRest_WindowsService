using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestWCFServiceLibrary.Use_Cases.HighScores.Interfaces;
using RestWCFServiceLibrary.Use_Cases.HighScores.Models;
using System.Collections.Generic;
using RestWCFServiceLibrary.Use_Cases.HighScores;

namespace RestWCFServiceLibraryUnitTests.Use_Cases.HighScores
{
    [TestClass]
    public class HighScoresControllerTests
    {
        [TestMethod]
        public void Test_GetAll()
        {
            var mockService = new Mock<IHighScoresService>();
            var mockResults = new List<HighScore>()
            {
                new HighScore() { Name = "Clark Kent", Score = 1 },
                new HighScore() { Name = "Bruce Wayne", Score = 2 },
            };

            mockService.Setup(service => service.ReadAll())
                        .Returns(mockResults);

            var controller = new HighScoresController(mockService.Object);
            var results = controller.GetAll();

            mockService.Verify(service => service.ReadAll(), Times.Once());

            Assert.AreEqual(mockResults, results);
            Assert.IsTrue(results.Count == 2);

            mockResults.Clear();

            results = controller.GetAll();
            Assert.AreEqual(mockResults, results);
            Assert.IsTrue(results.Count == 0);
        }

        [TestMethod]
        public void Test_Get()
        {
            var mockService = new Mock<IHighScoresService>();
            var mockResult = new HighScore() { Name = "Diana Prince", Score = 1 };

            mockService.Setup(service => service.Read(1))
                        .Returns(mockResult);

            var controller = new HighScoresController(mockService.Object);
            var result = controller.Get("1");

            mockService.Verify(service => service.Read(1), Times.Once());

            Assert.IsNotNull(result);
            Assert.AreEqual(mockResult, result);

            result = controller.Get("2");

            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "A non-int id should throw an exception")]
        public void Test_Get_Exception()
        {
            var mockService = new Mock<IHighScoresService>();
            var mockResult = new HighScore() { Name = "Diana Prince", Score = 1 };
            var controller = new HighScoresController(mockService.Object);

            controller.Get("Natasha Romanova");

            mockService.Verify(service => service.ReadAll(), Times.Never);
        }

        [TestMethod]
        public void Test_Post()
        {
            var mockService = new Mock<IHighScoresService>();

            mockService.Setup(service => service.Create(It.IsAny<HighScore>()));

            var controller = new HighScoresController(mockService.Object);
            var highScore = new HighScore() { Name = "Peter Parker", Score = 1 };

            controller.Post(highScore);

            mockService.Verify(service => service.Create(It.IsAny<HighScore>()), Times.Once());
        }

        [TestMethod]
        public void Test_Delete()
        {
            var mockService = new Mock<IHighScoresService>();
            var mockResults = new List<HighScore>()
            {
                new HighScore() { Name = "Clark Kent", Score = 1 },
                new HighScore() { Name = "Bruce Wayne", Score = 1 }
            };

            mockService.Setup(service => service.Delete(It.IsAny<int>()))
                       .Callback((int id) => mockResults.RemoveAll(hs => hs.Score == id));

            var controller = new HighScoresController(mockService.Object);

            Assert.IsTrue(mockResults.Count == 2);

            controller.Delete("1");
            mockService.Verify(service => service.Delete(It.IsAny<int>()), Times.Once());

            Assert.IsTrue(mockResults.Count == 1);
            Assert.IsTrue(mockResults[0].Name.Equals("Bruce Wayne"));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "A non-int id should throw an exception")]
        public void Test_Delete_Exception()
        {
            var mockService = new Mock<IHighScoresService>();
            var controller = new HighScoresController(mockService.Object);

            controller.Delete("Tony Stark");

            mockService.Verify(service => service.Delete(It.IsAny<int>()), Times.Never);
        }
    }
}
