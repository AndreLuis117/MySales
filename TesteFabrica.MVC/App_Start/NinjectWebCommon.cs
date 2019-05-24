[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TesteFabrica.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(TesteFabrica.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace TesteFabrica.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using TesteFabrica.Application;
    using TesteFabrica.Application.Interface;
    using TesteFabrica.Domain.Interfaces;
    using TesteFabrica.Domain.Interfaces.Services;
    using TesteFabrica.Domain.Services;
    using TesteFabrica.Infra.Data.Repositories;

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
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<IProdutoAppService>().To<ProdutoAppService>();
            kernel.Bind<IPedidoAppService>().To<PedidoAppService>();
            kernel.Bind<IItensPedidoAppService>().To<ItensPedidoAppService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IProdutoService>().To<ProdutoService>();
            kernel.Bind<IPedidoService>().To<PedidoService>();
            kernel.Bind<IItensPedidoService>().To<ItensPedidoService>();

            kernel.Bind(typeof(IBaseRepositorio<>)).To(typeof(RepositorioBase<>));
            kernel.Bind<IProdutoRepositorio>().To<RepositorioProduto>();
            kernel.Bind<IPedidoRepositorio>().To<RepositorioPedido>();
            kernel.Bind<IItensPedidoRepositorio>().To<RepositorioItensPedido>();
        }        
    }
}
