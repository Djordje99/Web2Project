using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2Project_FoodDelivery.DTO;
using Web2Project_FoodDelivery.Models;

namespace Web2Project_FoodDelivery.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserModel, UserDto>().ReverseMap();
            CreateMap<OrderModel, OrderDto>().ReverseMap();
            CreateMap<ProductModel, ProductDto>().ReverseMap();
            CreateMap<OrderDetailsModel, OrderDetailsDto>().ReverseMap();
            CreateMap<DeliveryModel, DeliveryDto>().ReverseMap();
        }
    }
}
