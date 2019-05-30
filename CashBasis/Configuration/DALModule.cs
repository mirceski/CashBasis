using CashBasis.DAL.Interfaces;
using CashBasis.DAL.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Module = Autofac.Module;
using Autofac;

namespace CashBasis.Configuration
{
    public class DALModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterAssemblyTypes(Assembly.Load("CashBasis.DAL"))
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            containerBuilder.RegisterType<UnitOfWork>()
                         .As<IUnitOfWork>()
                         .InstancePerLifetimeScope();
        }
    }
}
