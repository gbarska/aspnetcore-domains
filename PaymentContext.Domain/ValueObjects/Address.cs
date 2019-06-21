using Flunt.Validations;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : Shared.ValueObjects.ValueObject
    {
        public Address(string street, string number, string neighborhood, string city, string state, string country, string zipcode)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            Zipcode = zipcode;

            AddNotifications(new Contract()
            .Requires()
            .HasMinLen(Street,5,"Street", "Valor inválido")
            .HasMinLen(City,10,"City", "Valor inválido")
            .HasMaxLen(Zipcode,8,"Zipcode", "Valor inválido")
            );
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string Zipcode { get; private set; }
    }
}