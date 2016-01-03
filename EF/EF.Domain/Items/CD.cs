using System;
using System.Collections.Generic;

namespace EF.Domain.Items
{
    public class CD : LibraryItem
    {
        public string Artist { get; set; }
        public int TracksNumber { get; set; }
    }
}