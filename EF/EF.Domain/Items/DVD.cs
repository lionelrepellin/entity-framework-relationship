using EF.Domain.Catalogs;
using System;
using System.Collections.Generic;

namespace EF.Domain.Items
{
    public class Dvd : LibraryItem
    {
        public string Summary { get; private set; }
        public int Duration { get; private set; }

        public ICollection<Genre> Genres { get; private set; }

        public Dvd()
            : base()
        {
            // parameterless constructor used by EF
        }

        public Dvd(ItemStatus status, Language language, string title, Catalog catalog, string summary, int duration, ICollection<Genre> genres) :
            base(status, language, title, catalog)
        {
            Summary = summary;
            Duration = duration;
            Genres = genres;
        }
    }
}
