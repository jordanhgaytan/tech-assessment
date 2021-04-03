using System;

namespace Assessment.Dtos
{
    public record OrderDto
    {
        public Guid Id { get; init; }
        
        public string Customer { get; init; }

        public string OrderDesc { get; init; }

        public int OrderSku {get; init; }
    }
}