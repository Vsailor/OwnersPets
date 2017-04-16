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
            await _petsService.DeletePet(request.PetId);
        }

        /// <summary>
        /// Creates pet
        /// </summary>
        /// <param name="request">Data from request body</param>
        /// <returns>Task</returns>
        public async Task CreatePet(CreatePetRequest request)
        {
            await _petsService.CreatePet(request.PetName, request.OwnerId);
        }
    }
}