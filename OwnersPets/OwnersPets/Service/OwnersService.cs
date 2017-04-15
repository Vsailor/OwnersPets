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
                    new OwnerBasicInfo { Name = "Bob", PetsCount = 10 },
                    new OwnerBasicInfo { Name = "Simpsons", PetsCount = 20 },
                    new OwnerBasicInfo { Name = "Michael", PetsCount = 30 },
                    new OwnerBasicInfo { Name = "Mark", PetsCount = 3 },
                    new OwnerBasicInfo { Name = "Andrew", PetsCount = 12 },
                    new OwnerBasicInfo { Name = "Thomas", PetsCount = 15 },
                    new OwnerBasicInfo { Name = "Martin", PetsCount = 5 },
                    new OwnerBasicInfo { Name = "Batman", PetsCount = 7 },
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
    }
}
