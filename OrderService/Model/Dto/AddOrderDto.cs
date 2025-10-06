namespace OrderService.Model.Dto
{
    public class AddOrderDto
    {
        public string UserId { get; set; }
        public List<AddOrderLineDto> OrderLines { get; set; }

    }
}
