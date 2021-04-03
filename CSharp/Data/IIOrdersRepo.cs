using System;
using System.Collections.Generic;
using Assessment.Methods;

namespace Assessment.Data
{
    public interface IIOrdersRepo
    {
        Order GetOrder(Guid id);
        IEnumerable<Order> GetAllOrders();
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Guid id);
    }
}