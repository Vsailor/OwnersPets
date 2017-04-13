using Microsoft.Practices.Unity;
using OwnersPets.Abstract;
using OwnersPets.Service;

namespace OwnersPets
{
    public class OwnersPetsRegistration
    {
        public static void Register(UnityContainer container)
        {
            container.RegisterType<IOwnersService, OwnersService>();
        }
    }
}
