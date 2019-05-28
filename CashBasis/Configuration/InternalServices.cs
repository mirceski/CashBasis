using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Module = Autofac.Module;

namespace CashBasis.Configuration
{
    public class InternalServices : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterAssemblyTypes(Assembly.Load("CashBasis.Services"))
                   .Where(t => t.Name.EndsWith("Service") || t.Name.EndsWith("Implementation"))
                   .AsImplementedInterfaces()
                   .InstancePerRequest();
        }
    }
}
