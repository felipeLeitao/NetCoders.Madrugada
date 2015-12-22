[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NetCoders.Madrugada.UI.WEB.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NetCoders.Madrugada.UI.WEB.App_Start.NinjectWebCommon), "Stop")]

namespace NetCoders.Madrugada.UI.WEB.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using NetCoders.Madrugada.Service.Interface;
    using NetCoders.Madrugada.Service;
    using NetCoders.Madrugada.Domain.Repositories;
    using NetCoders.Madrugada.DataAccess.Repositories;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IFicanteRepository>().To<FicanteRepository>();
            kernel.Bind<ITelefoneRepository>().To<TelefoneRepository>();

            kernel.Bind<IFicanteService>().To<FicanteService>();
            kernel.Bind<ITelefoneService>().To<TelefoneService>();


        }        
    }
}
