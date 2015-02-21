using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using System.Threading.Tasks;
using powerpollService.Controllers.TwitterController;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tweetinvi;
using Tweetinvi.Core.Interfaces.Models;
using powerpollService.DataObjects;
using Newtonsoft.Json;

namespace powerpollService.Tests
{
    [TestClass]
    public class TwitterControllerTest
    {
        [TestMethod]
        public void GetHashTagAndKeyword();
        {
            TwitterController controller = new TwitterController();
            string hTagKWord = controller.Get("bestanimal", "dog");
        }

    }
}