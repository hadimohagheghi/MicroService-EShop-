using AutoMapper;
using DiscountService.Model.Dto;
using DiscountService.Model.Entities;

namespace DiscountService.Infrastructure.MappingProfile
{
    public class DiscountMappingProfile : Profile
    {
        public DiscountMappingProfile()
        {
            CreateMap<DiscountCode, DiscountDto>().ReverseMap();

        }
    }
}
