using System;
using System.Collections.Generic;

namespace EF.Domain.Borrowers
{
    public class Borrower
    {
        public int Id { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public int Age { get; private set; }

        public Address Address { get; private set; }

        public ICollection<Loan> Loans { get; private set; }

        public Borrower()
        {
            // parameterless constructor used by EF
        }

        public Borrower(string firstname, string lastname, int age)
        {
            Firstname = firstname;
            Lastname = lastname;
            Age = age;
        }

        public Borrower(string firstname, string lastname, int age, Address address)
            : this(firstname, lastname, age)
        {
            Address = address;
        }
    }
}