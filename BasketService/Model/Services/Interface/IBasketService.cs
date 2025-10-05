using BasketService.Model.Dto;

namespace BasketService.Model.Services.Interface
{
    public interface IBasketService
    {
        /// <summary>
        /// نمایش سبد خرید به کاربر و اگر سبد وجود نداشت براش ایجاد کنه
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns>اطلاعات سبد رو برای کاربر ارسال می کنیم</returns>
        BasketDto GetOrCreateBasketForUser(string UserId);
        BasketDto GetBasket(string UserId);
        void AddItemToBasket(AddItemToBasketDto item);
        void RemoveItemFromBasket(Guid ItemId);
        void SetQuantities(Guid itemId, int quantity);
        void TransferBasket(string anonymousId, string UserId);

    }
}
