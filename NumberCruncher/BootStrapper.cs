using Microsoft.Extensions.DependencyInjection;
using StructureMap;

namespace NumberCruncher
{
    public class BootStrapper
    {
        private readonly Container _container;

        public BootStrapper()
        {
            _container = new Container();

            //I had used AutoFac at my last position.  The default container that comes with .Net core is fine for this, but I was just reading about StructureMap and it automates
            //a lot of this as long as you name things according to conventions.
            _container.Configure(config =>
            {
                config.Scan(_ =>
                {
                    _.AssemblyContainingType(typeof(Program));
                    _.WithDefaultConventions();
                    //Initially I had _.AddAllTypesOf<ICalculateService>() here.  But this would cause a tight coupling of each of the calculations to the container.  Since we want all strategies available in a context this would defeat the purpose of DI.
                });
                config.For<ICalculateServiceFactory>().Singleton().Use<CalculateServiceFactory>();
                ContainerExtensions.Populate((ConfigurationExpression) config, new ServiceCollection());
            });
            
        }

        public void Run()
        {
            var appController = _container.GetInstance<IAppController>();
            appController.Run();
        }

        public Container AppContainer => _container;
    }
}