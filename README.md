Notes

How to run migrations dotnet ef migrations add InitializeDb --project VehiclePriceCalculator.Infrastructure --startup-project VehiclePriceCalculator.WebApp dotnet ef database update --project VehiclePriceCalculator.Infrastructure --startup-project VehiclePriceCalculator.WebApp

ToDo -Modifications to be made to create a shared project to share Services across domain layers -finish UnitTest project
