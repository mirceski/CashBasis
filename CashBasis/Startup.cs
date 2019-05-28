using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using CashBasis.Configuration;
using CashBasis.DAL;
using CashBasis.Services.Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CashBasis
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IContainer ApplicationContainer { get; private set; }
        
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add services to the collection.
            services.AddMvc();

            services.AddDbContext<CBContext>(options =>
                     options.UseSqlServer(Configuration.GetConnectionString("CashBasisDatabase"),
                     b => b.MigrationsAssembly("CashBasis.DAL")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAutoMapper(typeof(ServicesMapping).GetType().Assembly);

            // Create the container builder.
            var builder = new ContainerBuilder();

            // Register dependencies, populate the services from
            // the collection, and build the container.
            //
            // Note that Populate is basically a foreach to add things
            // into Autofac that are in the collection. If you register
            // things in Autofac BEFORE Populate then the stuff in the
            // ServiceCollection can override those things; if you register
            // AFTER Populate those registrations can override things
            // in the ServiceCollection. Mix and match as needed.
            builder.Populate(services);
            builder.RegisterModule<DALModule>();
            builder.RegisterModule<InternalServices>();
            ApplicationContainer = builder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(ApplicationContainer);
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddDbContext<CBContext>(options =>
        //             options.UseSqlServer(Configuration.GetConnectionString("CashBasisDatabase"),
        //             b => b.MigrationsAssembly("CashBasis.DAL")));

            //services.RegisterAssemblyPublicNonGenericClasses()
            //        .Where(x => x.Name.EndsWith(“Service”))
            //        .AsPublicImplementedInterfaces();

            //builder.RegisterAssemblyTypes(Assembly.Load("EventsPlatform.DAL"))
            //            .Where(t => t.Name.EndsWith("Repository"))
            //            .AsImplementedInterfaces()
            //            .InstancePerRequest();

            //builder.RegisterType<UnitOfWork>()
            //             .As<IUnitOfWork>()
            //             .InstancePerRequest();

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //services.AddAutoMapper(typeof(ServicesMapping).GetType().Assembly);
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

    }
}
