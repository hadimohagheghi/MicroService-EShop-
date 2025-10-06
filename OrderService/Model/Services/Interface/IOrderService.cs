using OrderService.Model.Dto;

namespace OrderService.Model.Services.Interface
{
    public interface IOrderService
    {
        void AddOrder(AddOrderDto addOrder);
        List<OrderDto> GetOrdersForUser(string UserId);
        OrderDto GetOrderById(Guid Id);
    }
}
