using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Domain
{
    public class DVD : LibraryItem
    {
        public string Summary { get; set; }
        public int Duration { get; set; }
    }
}
