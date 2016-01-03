using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Domain.Items
{
    public class Book : LibraryItem
    {
        public string Author { get; set; }
        public string ISBN { get; set; }
    }
}
