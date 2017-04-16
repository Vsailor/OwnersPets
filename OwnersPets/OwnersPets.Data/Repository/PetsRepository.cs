using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using OwnersPets.Data.Abstract;
using OwnersPets.Data.Models;
using OwnersPets.Data.Repository.Sql;
using StorageModel.Data;

namespace OwnersPets.Data.Repository
{
    public class PetsRepository : IPetsRepository
    {
        public async Task<GetPetByPetIdResult> GetPetDetailedInfo(int petId)
        {
            IEnumerable<GetPetByPetIdResult> result;
            using (var cnn = SimpleConnectionAdapter.SimpleDbConnection())
            {
                cnn.Open();
                result = await cnn.QueryAsync<GetPetByPetIdResult>(
                                string.Format(PetsQuery.GetPetByPetIdCommand, petId));
            }

            return result.FirstOrDefault();
        }

        public async Task<GetPetsByOwnerIdResult[]> GetPetsByOwnerId(int ownerId)
        {
            IEnumerable<GetPetsByOwnerIdResult> result;
            using (var cnn = SimpleConnectionAdapter.SimpleDbConnection())
            {
                cnn.Open();
                result = await cnn.QueryAsync<GetPetsByOwnerIdResult>(
                                string.Format(PetsQuery.GetPetsByOwnerIdCommand, ownerId));
            }

            return result.ToArray();
        }

        public async Task DeletePet(int petId)
        {
            using (var cnn = SimpleConnectionAdapter.SimpleDbConnection())
            {
                cnn.Open();
                await cnn.ExecuteAsync(string.Format(PetsQuery.DeletePetCommand, petId));
            }
        }

        public async Task CreatePet(string petName, int ownerId)
        {
            using (var cnn = SimpleConnectionAdapter.SimpleDbConnection())
            {
                cnn.Open();
                await cnn.ExecuteAsync(string.Format(PetsQuery.CreatePetCommand, petName, ownerId));
            }
        }
    }
}
