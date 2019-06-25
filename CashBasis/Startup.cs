using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using CashBasis.Configuration;
using CashBasis.Controllers;
using CashBasis.DAL;
using CashBasis.Services.Implementation;
using CashBasis.Services.Interfaces;
using CashBasis.Services.Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddControllersAsServices();
            
            services.AddDbContext<CBContext>(options =>
                     options.UseSqlServer(Configuration.GetConnectionString("CashBasisDatabase"),
                     b => b.MigrationsAssembly("CashBasis.DAL")));
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "CashBasis API", Version = "v1" });
            });
            
            services.AddAutoMapper(typeof(ServicesMapping));
            services.AddCors();

            var builder = new ContainerBuilder();
            
            builder.Populate(services);

            //var controllersTypesInAssembly = typeof(Startup).Assembly.GetExportedTypes()
            //.Where(type => typeof(ControllerBase).IsAssignableFrom(type)).ToArray();
            //builder.RegisterTypes(controllersTypesInAssembly).PropertiesAutowired();

            builder.RegisterAssemblyTypes(typeof(BaseController).GetTypeInfo().Assembly)
                .Where(t => typeof(Controller).IsAssignableFrom(t) &&
                        t.Name.EndsWith("Controller", StringComparison.Ordinal));

            //builder.RegisterType<ExpenseCategoryService>().As<IExpenseCategoryService>();

            builder.RegisterModule<DALModule>();
            builder.RegisterModule<InternalServices>();
            ApplicationContainer = builder.Build();
            
            return new AutofacServiceProvider(ApplicationContainer);
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CashBasis API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors(options =>
                options.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseMvc();

            
        }
    }
}
