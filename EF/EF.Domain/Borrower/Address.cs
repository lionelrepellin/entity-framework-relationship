using System;
using System.Collections.Generic;

namespace EF.Domain.Borrower
{
    public class Address
    {
        // PK & FK
        public int BorrowerId { get; set; }

        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }        
    }
}
