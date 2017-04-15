using Microsoft.Practices.Unity;
using OwnersPets.Data.Abstract;
using OwnersPets.Data.Repository;

namespace OwnersPets
{
    public class OwnersPetsRegistration
    {
        public static void Register(UnityContainer container)
        {
            container.RegisterType<IOwnersRepository, OwnersRepository>();
        }
    }
}
