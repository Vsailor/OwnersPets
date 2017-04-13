using Microsoft.Practices.Unity;
using OwnersPets.Presentation.Service;
using OwnersPets.Presentation.Service.Abstract;

namespace OwnersPets.Presentation
{
    public class OwnerPetsPresentationRegistration
    {
        public static void Register(UnityContainer container)
        {
            container.RegisterType<IOwnersPresentationService, OwnersPresentationService>();
        }
    }
}