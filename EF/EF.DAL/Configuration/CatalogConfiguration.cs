using EF.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DAL.Configuration
{
    public class CatalogConfiguration :EntityTypeConfiguration<Catalog>
    {
        public CatalogConfiguration()
        {
            ToTable("catalogue");
            HasKey(c => c.Id);

            Property(c => c.Id).HasColumnName("id");
            Property(c => c.Type).HasColumnName("type");

            // one-to-many relationship
            HasMany(c => c.Items)
                .WithRequired(l => l.Catalog)
                .HasForeignKey(l => l.CatalogId);
        }        
    }
}
