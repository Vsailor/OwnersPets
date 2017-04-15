﻿using System.Collections.Generic;
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
    }
}
