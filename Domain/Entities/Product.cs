using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        
        public Product(string name, string description, int quantity, decimal price)
        {
            Name = name;
            Description = description;
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
                Quantity -= qnt;
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
