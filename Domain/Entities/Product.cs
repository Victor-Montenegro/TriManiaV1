using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public Product(int quantity, decimal price)
        {
            Quantity = quantity;
            Price = price;
        }

        public bool HasStock(int qnt)
        {
            return Quantity >= qnt;
        }

        public void SellProduct(int qnt)
        {
            if(HasStock(qnt))
                Quantity--;
        }

        public void SetStock(int qnt)
        {
            Quantity += qnt;
        }

        public void SetPrice(decimal price)
        {
            Price = price;
        }
    }
}
