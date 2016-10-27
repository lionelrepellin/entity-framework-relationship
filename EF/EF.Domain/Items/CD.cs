using EF.Domain.Catalogs;
using System;
using System.Collections.Generic;

namespace EF.Domain.Items
{
    public class Cd : LibraryItem
    {
        public string Artist { get; private set; }
        public int TracksNumber { get; private set; }

        public Cd()
            : base()
        {
            // parameterless constructor used by EF
        }

        public Cd(ItemStatus status, Language language, string title, Catalog catalog, string artist, int trackNumber) :
            base(status, language, title, catalog)
        {
            Artist = artist;
            TracksNumber = trackNumber;
        }
    }
}