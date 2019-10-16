using Autofac;
using Domain.Repositories;
using Domain.SharedKernel;
using Persistence.EntityFramowork;

namespace TraingAppBackEnd.CompositionRoot
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterRepositories(builder);
        }

        void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(WriteRepository<>))
                .As(typeof(IWriteRepository<>));
        }
    }
}
