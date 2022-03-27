using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Address : BaseEntity
    {
        public string Street { get; private set; }
        public string Neighborhood { get; private set; }
        public string Number { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public User User { get; private set; }
        public int UserId { get; private set; }

        public Address(string street, string neighborhood, string number, string city, string state)
        {
            Street = street;
            Neighborhood = neighborhood;
            Number = number;
            City = city;
            State = state;
        }

        public Address SetUserId(int userId)
        {
            UserId = userId;

            return this;
        }
        public Address SetStreet(string street)
        {
            Street = street;

            return this;
        }
        public Address SetNeighborhood(string neighborhood)
        {
            Neighborhood = neighborhood;

            return this;
        }
        public Address SetNumber(string number)
        {
            Number = number;

            return this;
        }
        public Address SetCity(string city)
        {
            City = city;

            return this;
        }
        public Address SetState(string state)
        {
            State = state;

            return this;
        }
    }
}
