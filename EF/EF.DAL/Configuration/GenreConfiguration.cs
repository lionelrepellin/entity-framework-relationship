using EF.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DAL.Configuration
{
    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            ToTable("genre");
            HasKey(g => g.Id);

            Property(g => g.Id).HasColumnName("id");
            Property(g => g.Description).HasColumnName("description");
        }
    }
}
