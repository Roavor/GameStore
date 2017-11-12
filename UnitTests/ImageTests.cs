using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Domain.Abstract;
using Domain.Entities;
using WebUI.Controllers;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

namespace UnitTests
{
    public class ImageTests
    {
        public void Can_Retrieve_Image_Data()
        {
            Game game = new Game
            {
                GameId = 2,
                Name = "Game2",
                ImageData = new byte[] { },
                ImageMineType = "image/png"
            };
            Mock<IGameRepository> mock = new Mock<IGameRepository>();
            mock.Setup(m => m.Games).Returns(new List<Game>
            {
                new Game {GameId = 1, Name = "Игра1"},
                game,
                new Game {GameId = 3, Name = "Игра3"}
            }.AsQueryable());
            GameController controller = new GameController(mock.Object);
            ActionResult result = controller.GetImage(2);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(FileResult));
            Assert.AreEqual(game.ImageMineType, ((FileResult)result).ContentType);
        }
        [TestMethod]
        public void Cannot_Retrieve_Image_For_Invalid_Id()
        {
            Mock<IGameRepository> mock = new Mock<IGameRepository>();
            mock.Setup(m => m.Games).Returns(new List<Game>
            {
                new Game {GameId = 1, Name = "Игра1"},
                new Game {GameId = 3, Name = "Игра3"}
            }.AsQueryable());
            GameController controller = new GameController(mock.Object);
            ActionResult result = controller.GetImage(10);
            Assert.IsNull(result);
        }
    }
}
