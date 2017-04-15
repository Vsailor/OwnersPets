using System.Threading.Tasks;
using OwnersPets.Abstract;
using OwnersPets.Model;

namespace OwnersPets.Service
{
    public class OwnersService : IOwnersService
    {
        public async Task<OwnerBasicInfo[]> GetAllOwnersBasicInfo()
        {
            return await Task.Run(() =>
            {
                return new[]
                {
                    new OwnerBasicInfo { Name = "Bob", PetsCount = 10, OwnerId = 1 },
                    new OwnerBasicInfo { OwnerId = 2, Name = "Simpsons", PetsCount = 20 },
                    new OwnerBasicInfo { OwnerId = 3, Name = "Michael", PetsCount = 30 },
                    new OwnerBasicInfo { OwnerId = 4, Name = "Mark", PetsCount = 3 },
                    new OwnerBasicInfo { OwnerId = 5, Name = "Andrew", PetsCount = 12 },
                    new OwnerBasicInfo { OwnerId = 6, Name = "Thomas", PetsCount = 15 },
                    new OwnerBasicInfo { OwnerId = 7, Name = "Martin", PetsCount = 5 },
                    new OwnerBasicInfo { OwnerId = 8, Name = "Batman", PetsCount = 7 },
                };
            });
        }

        public async Task<OwnerDetailedInfo> GetOwnerDetails(int ownerId)
        {
            return await Task.Run(() =>
            {
                return new OwnerDetailedInfo
                {
                    OwnerName = "Martin",
                    Pets = new []
                    {
                        new PetBasicInfo
                        {
                            PetId = 1,
                            PetName = "Barsic"
                        }
                    }
                };
            });
        }

        public async Task DeleteOwner(int ownerId)
        {
            await Task.Run(() =>
            {
                
            });
        }

        public async Task<bool> IsOwnerExists(int ownerId)
        {
            return await Task.Run(() =>
            {
                return true;
            });
        }

        public async Task<bool> IsOwnerExists(string ownerName)
        {
            return await Task.Run(() =>
            {
                return false;
            });
        }

        public async Task CreateOwner(string ownerName)
        {
            await Task.Run(() =>
            {

            });
        }
    }
}
