using EF.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace EF.DAL.Configurations
{
    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            ToTable("genre");

            HasKey(g => g.Id);

            Property(g => g.Id)
                .HasColumnName("id");

            Property(g => g.Description)
                .HasColumnName("description");
        }
    }
}