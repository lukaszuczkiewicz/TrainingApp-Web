using Api.CompositionRoot;
using Autofac;

namespace TraingAppBackEnd.CompositionRoot
{
    public static class AutofacBuilderExtension
    {
        public static void RegisterModules(this ContainerBuilder builder)
        {
            builder.RegisterModule(new PlainCQRS.Autofac.AspNetCoreModule());

            builder.RegisterModule(new DomainModule());
            builder.RegisterModule(new Autofac());
            builder.RegisterModule(new AplicationModule());
            builder.RegisterModule(new WebModule());
            builder.RegisterModule(new GoogleAuthenticatorModule());
            builder.RegisterModule(new NotificationModule());
        }
    }
}
