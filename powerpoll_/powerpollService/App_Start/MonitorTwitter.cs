using System;
using System.Linq;
using System.Web.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.ScheduledJobs;
using Tweetinvi;
using Tweetinvi.Core.Events.EventArguments;
using powerpollService.Models;
using powerpollService.DataObjects;


namespace powerpollService
{
    public class MonitorTwitter
    {
        public static void monitor()
        {
            powerpollContext context = new powerpollContext();
            var stream = Stream.CreateUserStream();
            stream.TweetCreatedByAnyone += (s, t) =>
            {
                var hashtags = t.Tweet.Hashtags.ToArray()
                    .Select(x => x.Text.ToLowerInvariant());
                foreach (Poll poll in context.Polls)//go through all the polls
                {
                    if (hashtags.Contains(poll.Id))//if the tweet contains the poll Id as a hashtag
                    {
                        foreach (Result result in poll.Results)//go through the results of that poll
                        {
                            if (t.Tweet.Text.Contains(result.Id))//if the tweet contains that results id
                            {
                                result.Count++;
                                
                            }
                        }
                    }
                }
                context.SaveChanges();
            };
            stream.StartStream();
        }
    }
}