using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using powerpollService.Controllers;
using Tweetinvi;

namespace PowerpollTests
{
    [TestClass]
    public class TwitterControllerTest
    {
        [TestMethod]
        public void TestGet()
        {
            // Arrange
            var controller = new TwitterController();
            // Act
            string htag = controller.Get("bestanimal", "dog");
            // Assert
            // Do assertions here
        }
    }
}
