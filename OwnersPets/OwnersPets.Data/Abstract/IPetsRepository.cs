using System.Threading.Tasks;
using OwnersPets.Data.Models;

namespace OwnersPets.Data.Abstract
{
    public interface IPetsRepository
    {
        Task<GetPetByPetIdResult> GetPetDetailedInfo(int petId);

        Task<GetPetsByOwnerIdResult[]> GetPetsByOwnerId(int ownerId);

        Task DeletePet(int petId);

        Task CreatePet(string petName, int ownerId);
    }
}
