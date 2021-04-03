using System.ComponentModel.DataAnnotations;

namespace Assessment.Dtos
{
    public record UpdateOrderDto
    {
       [Required]
        public string Customer { get; init; }

        [Required]
        public string OrderDesc { get; init; }

        [Required]
        public int OrderSku {get; init; }
    }
}