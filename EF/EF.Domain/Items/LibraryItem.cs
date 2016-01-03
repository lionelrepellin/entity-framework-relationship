using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Domain.Items
{
    public class LibraryItem
    {
        public int Id { get; set; }
        public ItemStatus Status { get; set; }
        public Language Language { get; set; }
        public string Title { get; set; }

        public int CatalogId { get; set; }
        public virtual Catalog Catalog { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
    }    
}
