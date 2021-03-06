﻿using System.Threading.Tasks;
using OwnersPets.Model;

namespace OwnersPets.Abstract
{
    public interface IOwnersService
    {
        Task<OwnerBasicInfo[]> GetAllOwnersBasicInfo();

        Task<OwnerDetailedInfo> GetOwnerDetails(int ownerId);

        Task DeleteOwner(int ownerId);

        Task CreateOwner(string ownerName);
    }
}
