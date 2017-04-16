using System.Threading.Tasks;
using OwnersPets.Data.Models;

namespace OwnersPets.Data.Abstract
{
    public interface IOwnersRepository
    {
        Task<GetAllOwnerBasicInfoResult[]> GetAllOwnersBasicInfo();

        Task<GetOwnerByOwnerIdResult> GetOwnerDetailedInfo(int ownerId);

        Task DeleteOwner(int ownerId);

        Task CreateOwner(string ownerName);
    }
}
