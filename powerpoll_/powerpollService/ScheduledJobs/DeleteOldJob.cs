using System;
using System.Linq;
using System.Web.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.ScheduledJobs;
using powerpollService.Models;
using powerpollService.DataObjects;


namespace powerpollService
{
    // A simple scheduled job which can be invoked manually by submitting an HTTP
    // POST request to the path "/jobs/sample".

    public class DeleteOldJob : ScheduledJob
    {
        private powerpollContext context;

        protected override void Initialize(ScheduledJobDescriptor scheduledJobDescriptor, CancellationToken cancellationToken)
        {
            base.Initialize(scheduledJobDescriptor, cancellationToken);

            context = new powerpollContext();
        }

        public async override Task ExecuteAsync()
        {
            foreach(Poll poll in context.Polls){
                if (poll.End_Time <= DateTime.UtcNow)
                {
                    context.Polls.Remove(poll);
                }
            }
            await context.SaveChangesAsync();
        }
    }
}