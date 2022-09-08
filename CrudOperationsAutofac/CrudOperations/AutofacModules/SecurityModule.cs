using Autofac;
using Autofac.Configuration;
using CrudOperations.Repository;
using CrudOperations.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperationsAutofac.AutofacModules
{
    public class SecurityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SecurityRepository>().As<ISecurityRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SecurityService>().As<ISecurityService>().InstancePerLifetimeScope();
        }
    }
}
