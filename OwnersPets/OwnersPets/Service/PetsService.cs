using System.Collections.Generic;
using System.Threading.Tasks;
using OwnersPets.Abstract;

namespace OwnersPets.Service
{
    public class PetsService : IPetsService
    {
        public async Task DeletePet(int petId)
        {
            await Task.Run(() =>
            {

            });
        }

        public async Task<bool> IsPetExists(int petId)
        {
            return await Task.Run(() =>
            {
                return false;
            });
        }

        public async Task<bool> VerifyOwnerHasThisPet(string petName, int ownerId)
        {
            return await Task.Run(() =>
            {
                return false;
            });
        }

        public async Task CreatePet(string petName, int ownerId)
        {
            await Task.Run(() =>
            {

            });
        }
    }
}
