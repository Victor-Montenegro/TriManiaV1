using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Address : BaseEntity
    {
        public string Street { get; set; }

        public string Neighborhood { get; set; }

        public string Number { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public User User { get; set; }
    }
}
