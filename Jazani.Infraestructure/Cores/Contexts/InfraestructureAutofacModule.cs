﻿using Autofac;
using System.Reflection;

namespace Jazani.Infrastructure.Cores.Contexts
{
    public class InfraestructureAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

        }
    }
}
