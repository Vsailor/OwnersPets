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
                    new Owner { Name = "Bob", PetsCount = 10 }
                };
            });
        }
    }
}
