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
    // A simple scheduled job which can be invoked manually by submitting an HTTP
    // POST request to the path "/jobs/monitortwitter".

    public class sampleJob : ScheduledJob
    {
        private powerpollContext context;

        protected override void Initialize(ScheduledJobDescriptor scheduledJobDescriptor, CancellationToken cancellationToken)
        {
            base.Initialize(scheduledJobDescriptor, cancellationToken);

            context = new powerpollContext();
        }

        public async override Task ExecuteAsync()
        {
            var stream = Stream.CreateUserStream();
            stream.TweetCreatedByAnyoneButMe += (s, t) =>
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
                                Services.Log.Info(result.Id + " incremented");
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