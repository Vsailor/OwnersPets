using System.Threading.Tasks;
using OwnersPets.Model;

namespace OwnersPets.Abstract
{
    public interface IOwnersService
    {
        Task<OwnerBasicInfo[]> GetAllOwnersBasicInfo();

        Task<OwnerDetailedInfo> GetOwnerDetails(int ownerId);

        Task DeleteOwner(int ownerId);

        Task<bool> IsOwnerExists(int ownerId);

        Task<bool> IsOwnerExists(string ownerId);

        Task CreateOwner(string ownerName);
    }
}
