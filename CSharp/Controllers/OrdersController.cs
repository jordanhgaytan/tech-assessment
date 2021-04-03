using System;
using System.Collections.Generic;
using System.Linq;
using Assessment.Dtos;
using Assessment.Methods;
using Assessment.Data;
using Microsoft.AspNetCore.Mvc;
using Assessment;


namespace Catalog.Controllers
{
    [ApiController]
    [Route("customers")]
       public class OrdersController : ControllerBase
    {
        private readonly IIOrdersRepo repository;

        public OrdersController(IIOrdersRepo repository)
        {
            this.repository = repository;
        }

        // GET /orders
        [HttpGet]
        public IEnumerable<OrderDto> GetAllOrders()
        {
            var orders = repository.GetAllOrders().Select(order => order.AsDto());
            return orders;
        }

        // GET /order/{id}
        [HttpGet("{id}")]
        public ActionResult<OrderDto> GetOrder(Guid id)
        {
            var order = repository.GetOrder(id);

            if (order is null)
            {
                return NotFound();
            }

            return order.AsDto();
        }

        // POST /orders
        [HttpPost]
        public ActionResult<OrderDto> CreateOrder(CreateOrderDto orderDto)
        {
            Order order = new()
            {
                Id = Guid.NewGuid(),
                Customer = orderDto.Customer,
                OrderDesc = orderDto.OrderDesc,
                OrderSku = orderDto.OrderSku
            };

            repository.CreateOrder(order);

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order.AsDto());
        }

        // PUT /orders/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateOrder(Guid id, UpdateOrderDto OrderDto)
        {
            var existingOrder = repository.GetOrder(id);

            if (existingOrder is null)
            {
                return NotFound();
            }

            Order updatedOrder = existingOrder with
            {
                Customer = OrderDto.Customer,
                OrderDesc = OrderDto.OrderDesc,
                OrderSku = OrderDto.OrderSku           
            };

            repository.UpdateOrder(updatedOrder);

            return NoContent();
        }

        // DELETE /orders/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(Guid id)
        {
            var existingOrder = repository.GetOrder(id);

            if (existingOrder is null)
            {
                return NotFound();
            }

            repository.DeleteOrder(id);

            return NoContent();
        }
    }
}