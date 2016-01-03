﻿using System;
using System.Collections.Generic;

namespace EF.Domain.Items
{
    public class DVD : LibraryItem
    {
        public string Summary { get; set; }
        public int Duration { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }
    }
}
