using Autofac;
using Persistence.Abstractions;
using TraingAppBackEnd.Configuration;

namespace TraingAppBackEnd.CompositionRoot
{
    public class Autofac : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterAll(builder);
        }

        private void RegisterAll(ContainerBuilder builder)
        {
            builder.RegisterType<DbConfigProvider>()
                .As<IDbConfigProvider>()
                .InstancePerLifetimeScope();
        }
    }
}
