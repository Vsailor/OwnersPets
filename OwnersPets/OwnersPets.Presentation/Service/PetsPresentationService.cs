using System.Net;
using System.Threading.Tasks;
using System.Web;
using OwnersPets.Abstract;
using OwnersPets.Presentation.Models;
using OwnersPets.Presentation.Service.Abstract;

namespace OwnersPets.Presentation.Service
{
    public class PetsPresentationService : IPetsPresentationService
    {
        private readonly IPetsService _petsService;
        public PetsPresentationService(IPetsService petsService)
        {
            _petsService = petsService;
        }

        /// <summary>
        /// Deletes pet
        /// </summary>
        /// <param name="request">Data from request body</param>
        /// <returns>Task</returns>
        public async Task DeletePet(DeletePetRequest request)
        {
            bool petExists = await _petsService.IsPetExists(request.PetId);

            if (!petExists)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Pet not found");
            }

            await _petsService.DeletePet(request.PetId);
        }

        /// <summary>
        /// Creates pet
        /// </summary>
        /// <param name="request">Data from request body</param>
        /// <returns>Task</returns>
        public async Task CreatePet(CreatePetRequest request)
        {
            bool petExists = await _petsService.VerifyOwnerHasThisPet(request.PetName, request.OwnerId);
            if (petExists)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "This pet already exists");
            }

            await _petsService.CreatePet(request.PetName, request.OwnerId);
        }
    }
}