# Vehicle Price Calculator

## Overview

The Vehicle Price Calculator is a .NET Core application designed to help buyers calculate the total price of a vehicle at a car auction. It implements features such as dynamic fee calculation based on the vehicle type and price, displaying a breakdown of costs, and automatically updating the total cost whenever the price or type changes.

## Technologies and Libraries Used

- **Technologies**: .NET Core, C#, HTML, CSS, Bootstrap, Angular, JavaScript
- **Libraries**: MediatR, Serilog, Entity Framework, AutoMapper, xUnit (for Unit Tests)
- **Design Patterns**: Clean Architecture, CQRS, Unit of Work, MVC

## How to Run Migrations

Use the following commands to run migrations:

dotnet ef migrations add InitializeDb --project VehiclePriceCalculator.Infrastructure --startup-project VehiclePriceCalculator.WebApp
dotnet ef database update --project VehiclePriceCalculator.Infrastructure --startup-project VehiclePriceCalculator.WebApp

## Requirements

- Users can enter the vehicle base price and specify the vehicle type (Common or Luxury).
- The application displays a list of fees and their amounts.
- The total cost is automatically computed and displayed every time the price or type changes.

## List of Fixed and Variable Costs

- **Basic User Fee**: 10% of the vehicle price (minimum $10, maximum $50).
- **Common Car Special Fee**: 2% of the vehicle price.
- **Luxury Car Special Fee**: 4% of the vehicle price.
- **Association Fee**: Based on the price of the vehicle.
  - $5 for an amount between $1 and $500.
  - $10 for an amount between $501 and $1000.
  - $15 for an amount between $1001 and $3000.
  - $20 for amounts over $3000.
- **Storage Fee**: Fixed fee of $100.

## Calculation Example

For example, if the vehicle price is $1,000 and it's a common car:

- **Basic Fee**: $50 (10% of $1,000)
- **Special Fee**: $20 (2% of $1,000)
- **Association Fee**: $10
- **Storage Fee**: $100
- **Total**: $1,180


## Image
![image](https://github.com/spalmer8891/VehiclePriceCalculator/assets/48135720/5bbc1a78-625f-4460-82ff-c9485969c068)


