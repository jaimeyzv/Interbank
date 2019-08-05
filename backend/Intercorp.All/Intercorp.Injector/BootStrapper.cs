using Intercorp.Data.Repositories;
using Intercorp.Domain.Interfaces;
using Unity;

namespace Intercorp.Injector
{
    public class BootStrapper
    {
        public IUnityContainer RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IClientRepository, ClientRepository>();

            return container;
        }
    }
}
