using EF.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DAL.Configuration
{
    public class CdConfiguration : EntityTypeConfiguration<CD>
    {
        public CdConfiguration()
        {
            Property(c => c.Artist).HasColumnName("artiste");
            Property(c => c.TracksNumber).HasColumnName("nb_pistes");
        }
    }
}
