namespace BasketService.Model.Entities
{
    public class Basket
    {
        //بعداً برای کاربران ناشناس هم یک شناسه کاربری ایجاد می‌کنیم 
        public Basket(string UserId)
        {
            this.UserId = UserId;
        }
        public Basket()
        {
        }
        public Guid Id { get; set; }
        public string UserId { get; private set; }

        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
}
