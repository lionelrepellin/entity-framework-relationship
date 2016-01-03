using System;
using System.Collections.Generic;

namespace EF.Domain.Borrower
{
    public class Borrower
    {
        public int Id { get; set; }        
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }        
    }
}