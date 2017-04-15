using Microsoft.Practices.Unity;
using OwnersPets.Data.Abstract;
using OwnersPets.Data.Repository;

namespace OwnersPets.Data
{
    public class OwnerPetsDataRegistration
    {
        public static void Register(UnityContainer container)
        {
            container.RegisterType<IOwnersRepository, OwnersRepository>();
            container.RegisterType<IPetsRepository, PetsRepository>();
        }
    }
}
