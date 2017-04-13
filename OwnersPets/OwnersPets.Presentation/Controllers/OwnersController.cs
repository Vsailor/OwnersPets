using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using OwnersPets.Model;
using OwnersPets.Presentation.Service.Abstract;

namespace OwnersPets.Presentation.Controllers
{
    [RoutePrefix("api/Owners")]
    public class OwnersController : ApiController
    {
        private readonly IOwnersPresentationService _ownersPresentationService;

        public OwnersController(IOwnersPresentationService ownersPresentationService)
        {
            _ownersPresentationService = ownersPresentationService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Owner>> GetAll()
        {
            return await _ownersPresentationService.GetAllOwners();
        }
    }
}
