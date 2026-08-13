using AutoMapper;
using E_Commerce.Application.DTOs.Baskets;
using E_Commerce.Domain.Entities.Basckets;

namespace E_Commerce.Application.Profiles
{
    internal class BasketProfile :Profile
    {
        public BasketProfile()
        {

            CreateMap<CustomerBasket, BasketDto>();

            CreateMap<BasketItem, BasketItemDto>().ReverseMap();



        }
    }
}
