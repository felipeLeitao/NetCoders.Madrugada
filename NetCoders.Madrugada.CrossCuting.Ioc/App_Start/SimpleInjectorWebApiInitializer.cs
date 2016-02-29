//[assembly: WebActivator.PostApplicationStartMethod(typeof(LGroup.ProjetoPraticoDDD.AnaliseCredito.Infra.CrossCuting.Ioc.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace NetCoders.Madrugada.CrossCuting.Ioc
{
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using Microsoft.Practices.ServiceLocation;
    using CommonServiceLocator.SimpleInjectorAdapter;
    using NetCoders.Madrugada.Service.Interface;
    using NetCoders.Madrugada.Domain.Contracts.UnityOfWork;
    using NetCoders.Madrugada.Service;
    using NetCoders.Madrugada.DataAccess.UnityOfWork;
    using NetCoders.Madrugada.DataAccess.Context;
    using NetCoders.Madrugada.Domain.Repositories;
    using NetCoders.Madrugada.DataAccess.Repositories;

    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize(this Container container)
        {
            //var container = new Container();
            //container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            //inicializando o container
            InitializeContainer(container);

            //Passando o container para o service locator
            ServiceLocator.SetLocatorProvider(() => new SimpleInjectorServiceLocatorAdapter(container));
        }

        private static void InitializeContainer(Container container)
        {
            //Quando eu injetar a interface IPropostaRepository
            //Eu terei a instância de PropostaRepository
            container.Register<IFicanteService, FicanteService>();
            container.Register<ITelefoneService, TelefoneService>();
            container.Register<IUsuarioService, UsuarioService>();

            container.Register<IFicanteRepository, FicanteRepository>();
            container.Register<ITelefoneRepository, TelefoneRepository>();
            container.Register<IUsuarioRepository, UsuarioRepository>();

            container.Register<IUnityOfWork, UnityOfWork>();

            //container.Register<SisTinderContext>();

            container.RegisterPerWebRequest<SisTinderContext>();

            //Quando eu injetar AnaliseCreditoContext
            //Eu terei a instância dele mesmo
            // container.RegisterWebApiRequest<SisTinderContext>();

            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
        }
    }
}
