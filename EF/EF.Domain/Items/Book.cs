using System;
using System.Collections.Generic;

namespace EF.Domain.Items
{
    public class Book : LibraryItem
    {
        public string Author { get; set; }
        public string ISBN { get; set; }
    }
}
