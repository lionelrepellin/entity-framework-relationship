using EF.Domain.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Domain
{
    public class Loan
    {
        public int Id { get; set; }
        public DateTime DateBorrowed { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? DateReturned { get; set; }

        public int BorrowerId { get; set; }
        public virtual EF.Domain.Borrower.Borrower Borrower { get; set; }

        public int LibraryItemId { get; set; }
        public virtual LibraryItem LibraryItem { get; set; }
    }
}