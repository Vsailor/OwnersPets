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

        public async Task<OwnerBasicInfo[]> GetAllOwners()
        {
            return await _ownersService.GetAllOwnersBasicInfo();
        }

        public async Task<OwnerDetailedInfo> GetOwnerDetailsById(int id)
        {
            return await _ownersService.GetOwnerDetails(id);
        }

        public async Task DeleteOwner(DeleteOwnerRequest request)
        {
            OwnerDetailedInfo ownerExists = await _ownersService.GetOwnerDetails(request.OwnerId);
            if (ownerExists == null)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Owner not found");
            }

            await _ownersService.DeleteOwner(request.OwnerId);
        }

        public async Task CreateOwner(CreateOwnerRequest request)
        {
            await _ownersService.CreateOwner(request.OwnerName);
        }
    }
}