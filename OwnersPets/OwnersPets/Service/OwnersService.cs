using System.Threading.Tasks;
using OwnersPets.Abstract;
using OwnersPets.Model;

namespace OwnersPets.Service
{
    public class OwnersService : IOwnersService
    {
        public async Task<Owner[]> GetAllOwners()
        {
            return await Task.Run(() =>
            {
                return new Owner[]
                {
                    new Owner { Name = "Bob", PetsCount = 10 },
                    new Owner { Name = "Simpsons", PetsCount = 20 },
                    new Owner { Name = "Michael", PetsCount = 30 },
                    new Owner { Name = "Mark", PetsCount = 3 },
                    new Owner { Name = "Andrew", PetsCount = 12 },
                    new Owner { Name = "Thomas", PetsCount = 15 },
                    new Owner { Name = "Martin", PetsCount = 5 },
                    new Owner { Name = "Batman", PetsCount = 7 },
                };
            });
        }
    }
}
