**Notes**

**Description**
This project was built using .Net Core

**Technologies** used .Net,C#,HTML,CSS,Bootstrap,Javascript
**Libraries** used MediatR,Serialog,EntityFramework,AutoMapper
**Design patterns** Clean Architecutre,CQRS,UnitOfWork,MVC

**How to run migrations**
dotnet ef migrations add InitializeDb --project VehiclePriceCalculator.Infrastructure --startup-project VehiclePriceCalculator.WebApp
dotnet ef database update --project VehiclePriceCalculator.Infrastructure --startup-project VehiclePriceCalculator.WebApp




