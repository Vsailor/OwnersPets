using System.Threading.Tasks;
using OwnersPets.Presentation.Models;

namespace OwnersPets.Presentation.Service.Abstract
{
    public interface IPetsPresentationService
    {
        Task DeletePet(DeletePetRequest request);

        Task CreatePet(CreatePetRequest request);
    }
}
