using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OwnersPets.Data.Abstract;
using OwnersPets.Data.Models;
using StorageModel.Data;
using Dapper;
using OwnersPets.Data.Repository.Sql;

namespace OwnersPets.Data.Repository
{
    public class OwnersRepository : IOwnersRepository
    {
        public async Task<GetAllOwnerBasicInfoResult[]> GetAllOwnersBasicInfo()
        {
            IEnumerable<GetAllOwnerBasicInfoResult> result;
            using (var cnn = SimpleConnectionAdapter.SimpleDbConnection())
            {
                cnn.Open();
                result = await cnn.QueryAsync<GetAllOwnerBasicInfoResult>(OwnersQuery.GetAllOwnersBasicInfoCommand);
            }

            return result.ToArray();
        }

        public async Task<GetOwnerByOwnerIdResult> GetOwnerDetailedInfo(int ownerId)
        {
            IEnumerable<GetOwnerByOwnerIdResult> result;
            using (var cnn = SimpleConnectionAdapter.SimpleDbConnection())
            {
                cnn.Open();
                result = await cnn.QueryAsync<GetOwnerByOwnerIdResult>(
                            string.Format(OwnersQuery.GetOwnerByOwnerIdCommand, ownerId));
            }

            return result.FirstOrDefault();
        }

        public async Task DeleteOwner(int ownerId)
        {
            using (var cnn = SimpleConnectionAdapter.SimpleDbConnection())
            {
                cnn.Open();
                await cnn.ExecuteAsync(string.Format(OwnersQuery.DeleteOwnerCommand, ownerId));
            }
        }

        public async Task CreateOwner(string ownerName)
        {
            using (var cnn = SimpleConnectionAdapter.SimpleDbConnection())
            {
                cnn.Open();
                await cnn.ExecuteAsync(string.Format(OwnersQuery.CreateOwnerCommand, ownerName));
            }
        }
    }
}
