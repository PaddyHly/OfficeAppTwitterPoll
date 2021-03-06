﻿using System;
using System.Linq;
using System.Web.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
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
            var stream = Stream.CreateUserStream();
            stream.TweetCreatedByAnyone += (s, t) =>
            {
                powerpollContext context = new powerpollContext();
                var hashtags = t.Tweet.Hashtags.ToArray()
                    .Select(x => x.Text.ToLowerInvariant());
                foreach (Poll poll in context.Polls.ToArray())//go through all the polls
                {
                    foreach (String hashtag in hashtags)//if the tweet contains the poll Id as a hashtag
                    {
                        if (hashtag.ToLowerInvariant().Equals(poll.Id.ToLowerInvariant()) && poll.End_Time >= DateTime.UtcNow)
                        {
                            String test = t.Tweet.Text.Replace("#" + poll.Id, "").ToLowerInvariant();//string of tweet to be tested against
                            test = test.Replace("@twitpollpp", "");
                            Regex rgx = new Regex("[^a-zA-Z0-9 ]");
                            test = rgx.Replace(test, "").Trim() + ".";
                            foreach (Result result in poll.Results.ToArray())//go through the results of that poll
                            {
                                if (test.Contains(result.Id.ToLowerInvariant()+"."))
                                {
                                    result.Count++;
                                    context.SaveChangesAsync();
                                }
                            }
                        }
                    }
                }
                context.SaveChanges();
            };
            while (true)
            {
                stream.StartStream();
            }
        }
    }
}