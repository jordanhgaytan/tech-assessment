using System;

namespace Assessment.Methods
{
    public record Order
    {
        public Guid Id { get; init; }
        public string Customer { get; init; }
        public string OrderDesc { get; init; }
        public int OrderSku { get; init; }
    }
}