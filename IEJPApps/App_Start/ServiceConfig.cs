using System.Reflection;
using IEJPApps.Services;
using IEJPApps.Services.Interfaces;
using Ninject;
using Ninject.Modules;

namespace IEJPApps
{
    public class ServiceConfig : NinjectModule
    {
        public override void Load()
        {
            Bind<ICookieService>().To<CookieService>();
        }
    }

    public class ServiceLocator
    {
        public static IKernel Kernel;

        public static IKernel Initialize()
        {
            if (Kernel == null)
            {
                Kernel = new StandardKernel();
                Kernel.Load(Assembly.GetExecutingAssembly());
            }
            return Kernel;
        }

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}