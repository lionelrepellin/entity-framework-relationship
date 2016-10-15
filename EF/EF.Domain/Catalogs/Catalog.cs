using EF.Domain.Items;
using System;
using System.Collections.Generic;

namespace EF.Domain.Catalogs
{
    public class Catalog
    {
        public int Id { get; set; }
        public CatalogType Type { get; set; }

        public ICollection<LibraryItem> Items { get; set; }
    }
}