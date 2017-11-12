using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebUI.Controllers;
using WebUI.Abstract;
using WebUI.Models;

namespace UnitTests
{
    /// <summary>
    /// Сводное описание для AdminSecurityTests
    /// </summary>
    [TestClass]
    public class AdminSecurityTests
    {
        [TestMethod]
        public void Can_Login_Valid_Credentials()
        {
            Mock<IAuthProvider> mock = new Mock<IAuthProvider>();
            mock.Setup(m => m.Authenticate("admin", "12345")).Returns(true);
            LoginViewModel model = new LoginViewModel
            {
                UserName = "admin",
                Password = "12345"

            };
            AccountController controller = new AccountController(mock.Object);
            ActionResult result = controller.Login(model,"/MyUrl");
            Assert.IsInstanceOfType(result,typeof(RedirectResult));
            Assert.AreEqual("/MyUrl", ((RedirectResult)result).Url); 
        }
        [TestMethod]
        public void Cannot_Login_With_Invalid_Data()
        {
            Mock<IAuthProvider> mock = new Mock<IAuthProvider>();
            mock.Setup(m => m.Authenticate("admin", "12345")).Returns(true);
            LoginViewModel model = new LoginViewModel
            {
                UserName = "BadUser",
                Password = "BadPass"

            };
            AccountController controller = new AccountController(mock.Object);
            ActionResult result = controller.Login(model, "/MyUrl");
            Assert.IsInstanceOfType(result,typeof(ViewResult));
            Assert.IsFalse(((ViewResult)result).ViewData.ModelState.IsValid);
        }
    }
}
