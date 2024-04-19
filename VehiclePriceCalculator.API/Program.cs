using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VehiclePriceCalculator.API.AutoMapperProfile;
using VehiclePriceCalculator.API.Interfaces;
using VehiclePriceCalculator.API.Services;
using VehiclePriceCalculator.Application.AutoMapperProfile;
using VehiclePriceCalculator.Application.CQRS.Queries;
using VehiclePriceCalculator.Application.Interfaces;
using VehiclePriceCalculator.Application.Services;
using VehiclePriceCalculator.Domain.Interfaces;
using VehiclePriceCalculator.Domain.Interfaces.Repositories;
using VehiclePriceCalculator.Domain.Services;
using VehiclePriceCalculator.Infrastructure.Data;
using VehiclePriceCalculator.Infrastructure.Interfaces;
using VehiclePriceCalculator.Infrastructure.Repository;
using VehiclePriceCalculator.Infrastructure.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json");

// Get IConfiguration instance
var configuration = builder.Configuration;

// Register DbContext with the connection string from configuration
builder.Services.AddDbContext<VehiclePriceCalculatorDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("ProgiConnectionString"))
);

// Add Domain Layer
builder.Services.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();
builder.Services.AddScoped<IVehiclePriceTransactionRepository, VehiclePriceTransactionRepository>();
builder.Services.AddScoped<IVehiclePriceCalculate, VehiclePriceCalculatorService>();

// Add Application Layer
builder.Services.AddScoped<IVehicleTypeService, VehicleTypeService>();
builder.Services.AddScoped<IVehiclePriceTransactionService, VehiclePriceTransactionService>();

// Add Infrastructure Layer
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Add Presentation Layer
builder.Services.AddScoped<IAPIService, APIService>();
builder.Services.AddAutoMapper(typeof(ApplicationMappingProfile), typeof(APIMappin---------------------------------------------------------gProfile));

// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetAllVehicleTypesQuery>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();