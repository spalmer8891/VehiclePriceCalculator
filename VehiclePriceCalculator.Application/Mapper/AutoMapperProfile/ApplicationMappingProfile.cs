using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePriceCalculator.Application.CQRS.Commands;
using VehiclePriceCalculator.Application.Models;
using VehiclePriceCalculator.Domain.Entities;

namespace VehiclePriceCalculator.Application.AutoMapperProfile
{
    public class ApplicationMappingProfile:Profile
    {

        public ApplicationMappingProfile()
        {

            CreateMap<VehicleType, VehicleTypeModel>().ReverseMap();
            CreateMap<VehiclePriceTransaction, VehiclePriceTransactionModel>().ReverseMap();
            CreateMap<VehiclePriceTransactionModel, AddVehiclePriceTransactionCommand>().ReverseMap();
            
        }

    }
}
