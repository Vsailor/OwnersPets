using System.Threading.Tasks;

namespace OwnersPets.Abstract
{
    public interface IPetsService
    {
        Task DeletePet(int petId);

        Task<bool> IsPetExists(int petId);

        Task<bool> VerifyOwnerHasThisPet(string petName, int ownerId);

        Task CreatePet(string petName, int ownerId);
    }
}
