using EF.Domain.Borrowers;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace EF.DAL.Configurations
{
    public class BorrowerAddressConfiguration : EntityTypeConfiguration<Address>
    {
        public BorrowerAddressConfiguration()
        {
            ToTable("adresse_emprunteur");

            HasKey(a => a.BorrowerId);

            Property(a => a.BorrowerId)
                .HasColumnName("emprunteur_id");

            Property(a => a.Street)
                .HasColumnName("rue");

            Property(a => a.Zip)
                .HasColumnName("code_postal");

            Property(a => a.City)
                .HasColumnName("ville");

            Property(a => a.Country)
                .HasColumnName("pays");
        }
    }
}