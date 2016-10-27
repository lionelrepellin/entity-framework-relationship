using EF.Domain.Borrowers;
using EF.Domain.Items;
using System;
using System.Collections.Generic;

namespace EF.Domain
{
    public class Loan
    {
        public DateTime DateBorrowed { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime? DateReturned { get; private set; }

        // FK
        public int BorrowerId { get; private set; }
        public virtual Borrower Borrower { get; private set; }

        // FK
        public int LibraryItemId { get; private set; }
        public virtual LibraryItem LibraryItem { get; private set; }

        public Loan()
        {
            // parameterless constructor used by EF
        }

        public Loan(Borrower borrower, LibraryItem libraryItem, DateTime dueDate)
        {
            Borrower = borrower;
            LibraryItem = libraryItem;
            DueDate = dueDate;
            DateBorrowed = DateTime.Now;
        }

        public Loan(Borrower borrower, LibraryItem libraryItem, DateTime dueDate, DateTime dateReturned)
            : this(borrower, libraryItem, dueDate)
        {
            DateReturned = dateReturned;
        }
    }
}