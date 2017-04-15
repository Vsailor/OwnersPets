using System.Threading.Tasks;
using OwnersPets.Abstract;
using OwnersPets.Model;
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
    }
}