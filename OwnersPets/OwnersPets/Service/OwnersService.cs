using System;
using System.Linq;
using System.Threading.Tasks;
using OwnersPets.Abstract;
using OwnersPets.Data.Abstract;
using OwnersPets.Data.Models;
using OwnersPets.Model;

namespace OwnersPets.Service
{
    public class OwnersService : IOwnersService
    {
        private readonly IOwnersRepository _ownersRepository;
        private readonly IPetsRepository _petsRepository;

        public OwnersService(
            IOwnersRepository ownersRepository,
            IPetsRepository petsRepository)
        {
            _ownersRepository = ownersRepository;
            _petsRepository = petsRepository;
        }

        public async Task<OwnerBasicInfo[]> GetAllOwnersBasicInfo()
        {
            GetAllOwnerBasicInfoResult[] basicInfoResult = await _ownersRepository.GetAllOwnersBasicInfo();
            return basicInfoResult.Select(b => 
                new OwnerBasicInfo
                {
                    OwnerId = b.OwnerId,
                    PetsCount = b.PetsCount,
                    Name = b.Name
                }).ToArray();
        }

        public async Task<OwnerDetailedInfo> GetOwnerDetails(int ownerId)
        {
            GetOwnerByOwnerIdResult owner = await _ownersRepository.GetOwnerDetailedInfo(ownerId);
            if (owner == null)
            {
                return null;
            }

            GetPetsByOwnerIdResult[] pets = await _petsRepository.GetPetsByOwnerId(ownerId);
            return new OwnerDetailedInfo
            {
                OwnerId = owner.RowId,
                OwnerName = owner.Name,
                Pets = pets.Select(p => 
                            new PetBasicInfo
                            {
                                PetId = p.RowId,
                                PetName = p.Name
                            })
            };
        }

        public async Task DeleteOwner(int ownerId)
        {
            await _ownersRepository.DeleteOwner(ownerId);
        }

        public async Task CreateOwner(string ownerName)
        {
            await _ownersRepository.CreateOwner(ownerName);
        }
    }
}
