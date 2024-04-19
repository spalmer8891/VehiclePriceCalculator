using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePriceCalculator.Application.Models;
using VehiclePriceCalculator.Domain.Entities;
using VehiclePriceCalculator.WebApp.ViewModels;

namespace VehiclePriceCalculator.WebApp.AutoMapperProfile
{
    public class WebAppMappingProfile:Profile
    {

        public WebAppMappingProfile()
        {
            CreateMap<VehicleTypeModel, VehicleTypeViewModel>().ReverseMap();
            CreateMap<VehiclePriceTransactionModel, VehiclePriceTransactionViewModel>().ReverseMap();
            //CreateMap<VehiclePriceTransaction, VehiclePriceTransactionModel>().ReverseMap();

        }

    }
}
