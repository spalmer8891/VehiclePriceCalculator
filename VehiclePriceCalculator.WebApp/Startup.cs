using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using VehiclePriceCalculator.Infrastructure.Data;
using VehiclePriceCalculator.Domain.Configuration;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using VehiclePriceCalculator.Application.AutoMapperProfile;
using VehiclePriceCalculator.Domain.Interfaces.Repositories;
using VehiclePriceCalculator.Infrastructure.Repository;
using VehiclePriceCalculator.Infrastructure.UnitOfWork;
using VehiclePriceCalculator.Domain.Entities;
using VehiclePriceCalculator.Application.Interfaces;
using VehiclePriceCalculator.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using VehiclePriceCalculator.Shared.Interfaces;
using VehiclePriceCalculator.Shared.Services;
using System.Reflection;
using VehiclePriceCalculator.Application.CQRS.Queries;
using MediatR;
using VehiclePriceCalculator.Application.CQRS.Commands;
using VehiclePriceCalculator.Shared.AutoMapperProfile;
using VehiclePriceCalculator.Domain.Interfaces;
using VehiclePriceCalculator.Domain.Services;
using VehiclePriceCalculator.Infrastructure.Logging;


namespace VehiclePriceCalculator.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureVehiclePriceCalculatorServices(services);

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }

        private void ConfigureVehiclePriceCalculatorServices(IServiceCollection services)
        {
            // Add Domain Layer
            services.Configure<Settings>(Configuration);
            services.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();
            services.AddScoped<IVehiclePriceTransactionRepository, VehiclePriceTransactionRepository>();
            services.AddScoped<IVehiclePriceCalculate, VehiclePriceCalculatorService>();

            // Add Application Layer
            services.AddScoped<IVehicleTypeService, VehicleTypeService>();
            services.AddScoped<IVehiclePriceTransactionService, VehiclePriceTransactionService>();

            // Add Infrastructure Layer
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();           
            services.AddDbContext<VehiclePriceCalculatorDbContext>(
                    options => options.UseSqlServer(Configuration.GetConnectionString("ProgiConnectionString"))
                    );

            // Add Presentation Layer
            services.AddScoped<IPresentationService, PresentationService>();
            services.AddAutoMapper(typeof(ApplicationMappingProfile), typeof(PresentationMappingProfile));
            //services.AddScoped<IIndexPageService, IndexPageService>();
            //services.AddAutoMapper(typeof(ApplicationMappingProfile), typeof(WebAppMappingProfile));

            // Add MediatR
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetAllVehicleTypesQuery>());

            //Logger
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

        }
    }
}

