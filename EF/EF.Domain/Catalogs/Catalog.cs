using EF.Domain.Items;
using System;
using System.Collections.Generic;

namespace EF.Domain.Catalogs
{
    public class Catalog
    {
        public int Id { get; private set; }
        public CatalogType Type { get; private set; }

        public ICollection<LibraryItem> Items { get; private set; }

        public Catalog()
        {
            // parameterless constructor used by EF
        }

        public Catalog(CatalogType type)
        {
            Type = type;
        }
    }
}