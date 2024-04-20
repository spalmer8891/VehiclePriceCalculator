using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePriceCalculator.Application.Models;
using VehiclePriceCalculator.Domain.Entities;
using VehiclePriceCalculator.Shared.Models;

namespace VehiclePriceCalculator.Shared.AutoMapperProfile
{
    public class PresentationMappingProfile:Profile
    {

        public PresentationMappingProfile()
        {
            CreateMap<VehicleTypeModel, VehicleTypeViewModel>().ReverseMap();
            CreateMap<VehiclePriceTransactionModel, VehiclePriceTransactionViewModel>().ReverseMap();

        }

    }
}
