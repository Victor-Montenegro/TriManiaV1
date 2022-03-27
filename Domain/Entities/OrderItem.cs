using Domain.Entities.Base;

namespace Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public decimal Price { get; private set; }
        public int Quantity { get; private  set; }
        public int OrderId { get; private set; }
        public int ProductId { get; private set; }
        public Order Order { get; private  set; }
        public Product Product { get; private set; }
       
        public OrderItem(decimal price, int quantity, int productId)
        {
            Price = price;
            Quantity = quantity;
            ProductId = productId;
        }

        public void SetPrice(decimal price)
        {
            Price = price;
        }

        public void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }

        public void SetOrderItem(int quantity, int price)
        {
            Price = price;
            Quantity = quantity;
        }

        public void SetOrderId(int orderId)
        {
            OrderId = orderId;
        }
    }
}