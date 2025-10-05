using AutoMapper;
using BasketService.Model.Dto;
using BasketService.Model.Entities;

namespace BasketService.Infrastructure.MappingProfile
{
    public class BasketMappingProfile : Profile
    {
        public BasketMappingProfile()
        {
            //فیلدهای یک Dto رو می خوایم به فیلدهای یک Entity مپ کنیم
            CreateMap<BasketItem, AddItemToBasketDto>().ReverseMap();
        }
    }
}
