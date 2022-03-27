using System;

namespace Core.Models
{
    public class OrderItemModel
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public int OrderId { get; set; }
    }
}
