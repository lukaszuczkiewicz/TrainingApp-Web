using Autofac;
using Persistence;
using Persistence.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraingAppBackEnd.Configuration;

namespace TraingAppBackEnd.CompositionRoot
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterDbAbstraction(builder);
        }

        private void RegisterDbAbstraction(ContainerBuilder builder)
        {
            builder.RegisterType<DbConfigProvider>()
                .As<IDbConfigProvider>()
                .InstancePerLifetimeScope();
        }
    }
}
