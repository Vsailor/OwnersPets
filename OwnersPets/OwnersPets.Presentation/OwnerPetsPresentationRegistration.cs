using Microsoft.Practices.Unity;
using OwnersPets.Abstract;
using OwnersPets.Presentation.Service;
using OwnersPets.Presentation.Service.Abstract;
using OwnersPets.Service;

namespace OwnersPets.Presentation
{
    public class OwnerPetsPresentationRegistration
    {
        public static void Register(UnityContainer container)
        {
            container.RegisterType<IOwnersPresentationService, OwnersPresentationService>();
            container.RegisterType<IPetsPresentationService, PetsPresentationService>();
            container.RegisterType<IOwnersService, OwnersService>();
            container.RegisterType<IPetsService, PetsService>();
        }
    }
}