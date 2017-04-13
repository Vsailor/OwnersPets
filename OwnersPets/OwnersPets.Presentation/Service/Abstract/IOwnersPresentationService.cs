using System.Threading.Tasks;
using OwnersPets.Model;

namespace OwnersPets.Presentation.Service.Abstract
{
    public interface IOwnersPresentationService
    {
        Task<Owner[]> GetAllOwners();
    }
}