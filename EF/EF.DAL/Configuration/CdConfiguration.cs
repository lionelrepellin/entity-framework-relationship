using EF.Domain.Items;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace EF.DAL.Configuration
{
    public class CdConfiguration : EntityTypeConfiguration<Cd>
    {
        public CdConfiguration()
        {
            Property(c => c.Artist).HasColumnName("artiste");
            Property(c => c.TracksNumber).HasColumnName("nb_pistes");
        }
    }
}