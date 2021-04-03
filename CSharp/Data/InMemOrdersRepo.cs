using System;
using System.Collections.Generic;
using System.Linq;
using Assessment.Data;
using Assessment.Methods;

namespace Assessment.Data
{
    public class InMemOrdersRepo : IIOrdersRepo
    {
        private readonly List<Order> orders = new()
        {
            new Order { Id = Guid.NewGuid(), Customer = "Tony Stark", OrderDesc = "Laptop", OrderSku = 1003 },
            new Order { Id = Guid.NewGuid(), Customer = "Steve Rodgers", OrderDesc = "Desktop", OrderSku = 1005 },
            new Order { Id = Guid.NewGuid(), Customer = "Bruce Wayne", OrderDesc = "Xbox", OrderSku = 1651 },
            new Order { Id = Guid.NewGuid(), Customer = "Tony Stark", OrderDesc = "Wii", OrderSku = 1541 },
            new Order { Id = Guid.NewGuid(), Customer = "Thor", OrderDesc = "PS4", OrderSku = 2354 },
            new Order { Id = Guid.NewGuid(), Customer = "Clark Kent", OrderDesc = "Xbox1", OrderSku = 6541 },
            new Order { Id = Guid.NewGuid(), Customer = "Diana", OrderDesc = "Switch", OrderSku = 1654 },
            new Order { Id = Guid.NewGuid(), Customer = "Victor Stone", OrderDesc = "Switch Pro", OrderSku = 1543 }
        };

        public IEnumerable<Order> GetAllOrders()
        {
            return orders;
        }

        public Order GetOrder(Guid id)
        {
            return orders.Where(order => order.Id == id).SingleOrDefault();
        }

        public void CreateOrder(Order order)
        {
            orders.Add(order);
        }

        public void UpdateOrder(Order order)
        {
            var index = orders.FindIndex(existingOrder => existingOrder.Id == order.Id);
            orders[index] = order;
        }

        public void DeleteOrder(Guid id)
        {
            var index = orders.FindIndex(existingOrder => existingOrder.Id == id);
            orders.RemoveAt(index);
        }
    }
}