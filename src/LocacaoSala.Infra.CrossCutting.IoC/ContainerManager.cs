using DryIoc;
using DryIoc.WebApi;
using LocacaoSala.Application.Core.Bus;
using LocacaoSala.Application.Domain.Handlers;
using LocacaoSala.Infra.CrossCutting.Core.Bus;
using LocacaoSala.Repository;
using MediatR;
using System.Reflection;
using System.Web.Http;

namespace LocacaoSala.Infra.CrossCutting.IoC
{
    public static class ContainerManager
    {
        private static IContainer Container;

        public static void Load(HttpConfiguration config)
        {
            var container = Initialize();
            Container = container.WithWebApi(config, throwIfUnresolved: type => type.IsController());

            Container.RegisterMany(new[] { typeof(IMediator).GetAssembly(), typeof(SalaRepository).GetAssembly(), typeof(SalaCommandHandler).GetAssembly() }, type => type.GetTypeInfo().IsInterface, reuse: Reuse.Singleton);
            Container.Register<IMediatorHandler, MediatorHandler>();
            Container.RegisterDelegate<SingleInstanceFactory>(r => r.Resolve, reuse: Reuse.Singleton);
            Container.RegisterDelegate<MultiInstanceFactory>(r => serviceType => r.ResolveMany(serviceType), reuse: Reuse.Singleton);
        }

        private static Container Initialize()
        {
            var container = new Container(
                    rules => rules
                        .WithFactorySelector(Rules.SelectLastRegisteredFactory())
                        .With(FactoryMethod.ConstructorWithResolvableArguments)
                        .WithoutThrowOnRegisteringDisposableTransient()
                        .WithoutThrowIfDependencyHasShorterReuseLifespan(),
                    scopeContext: new AsyncExecutionFlowScopeContext()
                );

            //string prefix = "LocacaoSala";

            //var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            //var loadedPaths = loadedAssemblies.Select(a => a.Location).ToArray();

            //var referencedPaths = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");

            //var toLoad = referencedPaths.Where(r => !loadedPaths.Contains(r, StringComparer.InvariantCultureIgnoreCase) && r.Contains(prefix)).ToList();

            //toLoad.ForEach(path => loadedAssemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(path))));

            //var implementingClasses =
            //    AppDomain.CurrentDomain.GetAssemblies().ToList()
            //        .Where(x => x.FullName.StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase))
            //        .SelectMany(x => x.GetTypes())
            //        .Where(type =>
            //            (type.Namespace != null && (type.Namespace.StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase))) &&
            //            type.IsPublic &&                    // get public types 
            //            !type.IsAbstract &&                 // which are not interfaces nor abstract
            //            type.GetInterfaces().Length != 0)   // which implementing some interface(s)
            //        .ToList();

            //Parallel.ForEach(implementingClasses, implementingClass =>
            //{
            //    Debug.WriteLine(implementingClass.Name);
            //    var serviceKey = implementingClass.Name;
            //    container.RegisterMany(new[] { implementingClass }, serviceTypeCondition: type => type.IsInterface, reuse: Reuse.Singleton, ifAlreadyRegistered: IfAlreadyRegistered.Replace);
            //});

            return container;
        }
    }
}
