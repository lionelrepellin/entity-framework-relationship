using System;
using System.Collections.Generic;

namespace EF.Domain.Borrowers
{
    public class Address
    {
        // PK & FK
        public int BorrowerId { get; private set; }

        public string Street { get; private set; }
        public string Zip { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }

        public Address()
        {
            // parameterless constructor used by EF
        }

        public Address(string street, string zip, string city, string country)
        {
            Street = street;
            Zip = zip;
            City = city;
            Country = country;
        }
    }
}
