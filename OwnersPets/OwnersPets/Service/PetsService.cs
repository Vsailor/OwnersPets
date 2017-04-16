using System.Threading.Tasks;
using OwnersPets.Abstract;
using OwnersPets.Data.Abstract;

namespace OwnersPets.Service
{
    public class PetsService : IPetsService
    {
        private readonly IPetsRepository _petsRepository;

        public PetsService(IPetsRepository petsRepository)
        {
            _petsRepository = petsRepository;
        }

        public async Task DeletePet(int petId)
        {
            await _petsRepository.DeletePet(petId);
        }

        public async Task CreatePet(string petName, int ownerId)
        {
            await _petsRepository.CreatePet(petName, ownerId);
        }
    }
}
