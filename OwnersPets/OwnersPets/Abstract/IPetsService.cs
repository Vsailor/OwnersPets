using System.Threading.Tasks;

namespace OwnersPets.Abstract
{
    public interface IPetsService
    {
        Task DeletePet(int petId);

        Task CreatePet(string petName, int ownerId);
    }
}
