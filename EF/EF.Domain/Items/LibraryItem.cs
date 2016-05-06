using EF.Domain.Catalogs;
using System;
using System.Collections.Generic;

namespace EF.Domain.Items
{
    public abstract class LibraryItem
    {
        public int Id { get; set; }
        public ItemStatus Status { get; set; }
        public Language Language { get; set; }
        public string Title { get; set; }

        // FK
        public int CatalogId { get; set; }
        public virtual Catalog Catalog { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
    }    
}
