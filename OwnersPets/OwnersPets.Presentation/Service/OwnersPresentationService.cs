using System.Net;
using System.Threading.Tasks;
using System.Web;
using OwnersPets.Abstract;
using OwnersPets.Model;
using OwnersPets.Presentation.Models;
using OwnersPets.Presentation.Service.Abstract;

namespace OwnersPets.Presentation.Service
{
    public class OwnersPresentationService : IOwnersPresentationService
    {
        private readonly IOwnersService _ownersService;

        public OwnersPresentationService(IOwnersService ownersService)
        {
            _ownersService = ownersService;
        }

        /// <summary>
        /// Gets all owners
        /// </summary>
        /// <returns>Basic info for all owners</returns>
        public async Task<OwnerBasicInfo[]> GetAllOwners()
        {
            return await _ownersService.GetAllOwnersBasicInfo();
        }

        /// <summary>
        /// Gets owner detailed information by ownerId
        /// </summary>
        /// <param name="id">Id of owner</param>
        /// <returns>Owner detailed information</returns>
        public async Task<OwnerDetailedInfo> GetOwnerDetailsById(int id)
        {
            return await _ownersService.GetOwnerDetails(id);
        }

        /// <summary>
        /// Deletes owner by ownerId
        /// </summary>
        /// <param name="ownerId">Id of owner</param>
        /// <returns>Task</returns>
        public async Task DeleteOwner(DeleteOwnerRequest request)
        {
            bool ownerExists = await _ownersService.IsOwnerExists(request.OwnerId);
            if (!ownerExists)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Owner not found");
            }

            await _ownersService.DeleteOwner(request.OwnerId);
        }

        public async Task CreateOwner(CreateOwnerRequest request)
        {
            bool ownerExists = await _ownersService.IsOwnerExists(request.OwnerName);
            if (ownerExists)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Owner with the same name already exists");
            }

            await _ownersService.CreateOwner(request.OwnerName);
        }
    }
}