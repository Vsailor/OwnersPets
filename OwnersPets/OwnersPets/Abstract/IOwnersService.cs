using System.Threading.Tasks;
using OwnersPets.Model;

namespace OwnersPets.Abstract
{
    public interface IOwnersService
    {
        Task<Owner[]> GetAllOwners();
    }
}
