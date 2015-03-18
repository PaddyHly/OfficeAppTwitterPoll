using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Threading;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Mobile.Service;
using powerpollService.DataObjects;
using powerpollService.Models;
using Tweetinvi;

namespace PowerpollTests
{
    [TestClass]
    public class PollResultsTest
    {
        [TestMethod]
        public void PollResults()
        {
            var context = new powerpollContext();
            var polls = context.Polls;
            string result1_Id = Guid.NewGuid().ToString();
            string result2_Id = Guid.NewGuid().ToString();
            string hashtag = Guid.NewGuid().ToString();
            List<Result> results = new List<Result>
            {
                new Result { Id = result1_Id, Count = 2, PollId = hashtag },
                new Result { Id = result2_Id, Count = 3, PollId = hashtag }
            };

            Poll poll = new Poll { Id = hashtag, End_Time = DateTime.Now, Results = results };
            foreach (Poll p in context.Polls)
            {
                Console.WriteLine(p.Id);
            }
            //context.Polls.Add(poll);
            //context.Set<Poll>().Add(poll);
            /*
            context.SaveChanges();
            polls = context.Polls;
            foreach (Poll i in polls)
            {
                foreach (Result result in i.Results)
                {
                    if (result.Id.Equals(result1_Id))
                    {
                        Assert.AreEqual<int>(2, result.Count);
                    }
                    else if (result.Id.Equals(result2_Id))
                    {
                        Assert.AreEqual<int>(3, result.Count);
                    }
                }
            }
             * */
        }
    }
}
