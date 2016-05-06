using EF.Domain.Borrowers;
using EF.Domain.Items;
using System;
using System.Collections.Generic;

namespace EF.Domain
{
    public class Loan
    {
        public DateTime DateBorrowed { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? DateReturned { get; set; }

        // FK
        public int BorrowerId { get; set; }
        public virtual Borrower Borrower { get; set; }

        // FK
        public int LibraryItemId { get; set; }
        public virtual LibraryItem LibraryItem { get; set; }
    }
}