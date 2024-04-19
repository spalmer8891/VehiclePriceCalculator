using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePriceCalculator.Application.Models;
using VehiclePriceCalculator.Domain.Entities;
using VehiclePriceCalculator.API.Models;

namespace VehiclePriceCalculator.API.AutoMapperProfile
{
    public class APIMappingProfile:Profile
    {

        public APIMappingProfile()
        {
            CreateMap<VehicleTypeModel, VehicleTypeViewModel>().ReverseMap();
            CreateMap<VehiclePriceTransactionModel, VehiclePriceTransactionViewModel>().ReverseMap();

        }

    }
}
