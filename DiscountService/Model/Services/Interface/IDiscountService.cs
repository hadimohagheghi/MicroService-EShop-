using DiscountService.Model.Dto;

namespace DiscountService.Model.Services.Interface
{
    public interface IDiscountService
    {
        DiscountDto GetDiscountByCode(string Code);
        bool UseDiscount(Guid Id);
        bool AddNewDiscount(string Code, int Amount);
        DiscountDto GetDiscountById(Guid parse);
    }
}
