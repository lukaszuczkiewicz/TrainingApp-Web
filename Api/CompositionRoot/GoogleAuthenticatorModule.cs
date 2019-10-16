using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraingAppBackEnd.GoogleAuthenticator;

namespace TraingAppBackEnd.CompositionRoot
{
    public class GoogleAuthenticatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterAll(builder);
        }

        private static void RegisterAll(ContainerBuilder builder)
        {
            builder.RegisterType<KeyService>()
                .As<IKeyService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PreSharedKey>()
                .As<IPreSharedKey>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TimeSensetivePassCode>()
                .As<ITimeSensetivePassCode>()
                .InstancePerLifetimeScope();
        }
    }
}
