using EF.Domain.Catalogs;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace EF.DAL.Configurations
{
    public class CatalogConfiguration :EntityTypeConfiguration<Catalog>
    {
        public CatalogConfiguration()
        {
            ToTable("catalogue");

            HasKey(c => c.Id);

            Property(c => c.Id)
                .HasColumnName("id");

            Property(c => c.Type)
                .HasColumnName("type");

            // one-to-many relationship
            // http://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx
            HasMany(c => c.Items)
                .WithRequired(l => l.Catalog)
                .HasForeignKey(l => l.CatalogId);
        }        
    }
}