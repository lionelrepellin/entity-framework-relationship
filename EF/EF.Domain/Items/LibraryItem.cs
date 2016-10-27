using EF.Domain.Catalogs;
using System;
using System.Collections.Generic;

namespace EF.Domain.Items
{
    public abstract class LibraryItem
    {
        public int Id { get; private set; }
        public ItemStatus Status { get; private set; }
        public Language Language { get; private set; }
        public string Title { get; private set; }

        // FK
        public int CatalogId { get; private set; }
        public Catalog Catalog { get; private set; }

        public ICollection<Loan> Loans { get; private set; }

        protected LibraryItem()
        {
            // parameterless constructor used by EF
        }

        protected LibraryItem(ItemStatus status, Language language, string title, Catalog catalog)
        {
            Status = status;
            Language = Language;
            Title = title;
            Catalog = catalog;
        }
    }
}