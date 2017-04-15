using System.Threading.Tasks;
using OwnersPets.Model;
using OwnersPets.Presentation.Models;

namespace OwnersPets.Presentation.Service.Abstract
{
    public interface IOwnersPresentationService
    {
        Task<OwnerBasicInfo[]> GetAllOwners();

        Task<OwnerDetailedInfo> GetOwnerDetailsById(int id);

        Task DeleteOwner(DeleteOwnerRequest request);

        Task CreateOwner(CreateOwnerRequest request);
    }
}