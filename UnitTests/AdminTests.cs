using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Domain.Abstract;
using Domain.Entities;
using WebUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace UnitTests
{
    /// <summary>
    /// Сводное описание для AdminTests
    /// </summary>
    [TestClass]
    public class AdminTests
    {
       

        [TestMethod]
        public void Index_Contains_All_Games()
        {
            Mock<IGameRepository> mock = new Mock<IGameRepository>();
            mock.Setup(m => m.Games).Returns(new List<Game>
            {
                new Game {GameId=1,Name="Game1" },
                new Game {GameId=2,Name="Game2" },
                new Game {GameId=3,Name="Game3" },
                new Game {GameId=4,Name="Game4" }
            });
            AdminController controller = new AdminController(mock.Object);
            List <Game> result = ((IEnumerable<Game>)controller.Index().ViewData.Model).ToList();
            Assert.AreEqual(result.Count(), 4);
            Assert.AreEqual(result[0].Name, "Game1");
            Assert.AreEqual(result[1].Name, "Game2");
            Assert.AreNotEqual(result[2].Name, "Game4","Are equal");


        }
    }
}
