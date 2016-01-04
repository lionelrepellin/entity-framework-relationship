using System;
using System.Collections.Generic;

namespace EF.Domain.Items
{
    public class Cd : LibraryItem
    {
        public string Artist { get; set; }
        public int TracksNumber { get; set; }
    }
}