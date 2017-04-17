using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using OwnersPets.Model;
using OwnersPets.Presentation.Models;
using OwnersPets.Presentation.Service.Abstract;

namespace OwnersPets.Presentation.ApiControllers
{
    [RoutePrefix("api/Owners")]
    public class OwnersApiController : ApiController
    {
        private readonly IOwnersPresentationService _ownersPresentationService;

        public OwnersApiController(
            IOwnersPresentationService ownersPresentationService)
        {
            _ownersPresentationService = ownersPresentationService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<OwnerBasicInfo>> GetAll()
        {
            return await _ownersPresentationService.GetAllOwners();
        }

        [HttpGet]
        [Route("{ownerId}")]
        public async Task<OwnerDetailedInfo> GetOwnerDetails([FromUri] int ownerId)
        {
            return await _ownersPresentationService.GetOwnerDetailsById(ownerId);
        }

        [HttpPost]
        [Route("Delete")]
        public async Task DeleteOwner([FromBody] DeleteOwnerRequest request)
        {
            if (request == null)
            {
                return;
            }

            await _ownersPresentationService.DeleteOwner(request);
        }

        [Route("Create")]
        public async Task CreateOwner([FromBody] CreateOwnerRequest request)
        {
            if (string.IsNullOrEmpty(request?.OwnerName) || !ModelState.IsValid)
            {
                return;
            }

            await _ownersPresentationService.CreateOwner(request);
        }
    }
}
