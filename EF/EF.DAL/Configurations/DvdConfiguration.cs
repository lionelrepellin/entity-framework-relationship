using EF.Domain.Items;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace EF.DAL.Configurations
{
    public class DvdConfiguration : EntityTypeConfiguration<Dvd>
    {
        public DvdConfiguration()
        {
            Property(d => d.Duration)
                .HasColumnName("duree");

            Property(d => d.Summary)
                .HasColumnName("resume");

            // many-to-many relationship
            // the table genre_article will be
            // automatically created
            // http://www.entityframeworktutorial.net/code-first/configure-many-to-many-relationship-in-code-first.aspx
            HasMany(d => d.Genres)
                .WithMany()
                .Map(x =>
                {
                    x.MapLeftKey("article_id");
                    x.MapRightKey("genre_id");
                    x.ToTable("genre_article");
                });
        }
    }
}