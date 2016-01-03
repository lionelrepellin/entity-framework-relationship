using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Domain.Items
{
    public class CD : LibraryItem
    {
        public string Artist { get; set; }
        public int TracksNumber { get; set; }
    }
}