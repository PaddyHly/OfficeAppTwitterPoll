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
    public class ResultController : TableController<Result>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            powerpollContext context = new powerpollContext();
            DomainManager = new EntityDomainManager<Result>(context, Request, Services);
        }

        // GET tables/PollResults
        public IQueryable<Result> GetAllPollResults()
        {
            return Query(); 
        }

        // GET tables/PollResults/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Result> GetPollResults(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/PollResults/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Result> PatchPollResults(string id, Delta<Result> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/PollResults
        public async Task<IHttpActionResult> PostPollResults(Result item)
        {
            Result current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/PollResults/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeletePollResults(string id)
        {
             return DeleteAsync(id);
        }

    }
}