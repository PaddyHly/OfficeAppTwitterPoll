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
    public class PollResultController : TableController<PollResult>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            powerpollContext context = new powerpollContext();
            DomainManager = new EntityDomainManager<PollResult>(context, Request, Services);
        }

        // GET tables/PollResult
        public IQueryable<PollResult> GetAllPollResult()
        {
            return Query(); 
        }

        // GET tables/PollResult/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<PollResult> GetPollResult(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/PollResult/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<PollResult> PatchPollResult(string id, Delta<PollResult> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/PollResult
        public async Task<IHttpActionResult> PostPollResult(PollResult item)
        {
            PollResult current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/PollResult/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeletePollResult(string id)
        {
             return DeleteAsync(id);
        }

    }
}