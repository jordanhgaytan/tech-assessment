using Assessment.Dtos;
using Assessment.Methods;

namespace Assessment
{
    public static class Extensions
    {
        public static OrderDto AsDto(this Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                Customer = order.Customer,
                OrderDesc = order.OrderDesc,
                OrderSku = order.OrderSku
            };
        }
    }
}