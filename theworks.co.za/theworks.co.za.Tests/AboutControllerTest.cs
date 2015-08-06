using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using theworks.co.za.Controllers;

namespace theworks.co.za.Tests
{
    [TestClass]
    public class AboutControllerTest
    {
        [TestMethod]
        public void About()
        {
            // Arrange
            AboutController controller = new AboutController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            ViewDataDictionary viewData = result.ViewData;

            Assert.AreEqual("Welcome to ASP.NET MVC!", viewData["Message"]);
        }
    }
}
