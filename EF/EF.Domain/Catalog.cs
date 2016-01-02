using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Domain
{
    public enum CatalogType
    {
        General,
        Other
    }

    public class Catalog
    {
        public int Id { get; set; }
        public CatalogType Type { get; set; }

        public ICollection<LibraryItem> Items { get; set; }
    }
}
