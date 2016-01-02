using EF.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DAL.Configuration
{
    public class DvdConfiguration : EntityTypeConfiguration<DVD>
    {
        public DvdConfiguration()
        {
            Property(d => d.Duration).HasColumnName("duree");
            Property(d => d.Summary).HasColumnName("resume");
        }
    }
}
