using System;
using System.Collections.Generic;

namespace EF.Domain
{
    public class Genre
    {
        public int Id { get; private set; }
        public string Description { get; private set; }

        public Genre()
        {
            // parameterless constructor used by EF
        }

        public Genre(string description)
        {
            Description = description;
        }

        public Genre(int id)
        {
            Id = id;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }        
    }
}