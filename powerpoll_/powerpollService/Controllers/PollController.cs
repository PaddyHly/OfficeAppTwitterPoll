using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using powerpollService.DataObjects;
using powerpollService.Models;

namespace powerpollService.Controllers
{
    public class PollController : TableController<Poll>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            powerpollContext context = new powerpollContext();
            DomainManager = new EntityDomainManager<Poll>(context, Request, Services);
        }

        // GET tables/Poll
        public IQueryable<Poll> GetAllPoll()
        {
            return Query();
        }

        // GET tables/Poll/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Poll> GetPoll(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Poll/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Poll> PatchPoll(string id, Delta<Poll> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Poll
        public async Task<IHttpActionResult> PostPoll(Poll item)
        {
            Poll current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Poll/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeletePoll(string id)
        {
             return DeleteAsync(id);
        }

    }
}