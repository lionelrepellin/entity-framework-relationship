using EF.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace EF.DAL.Configuration
{
    public class LoanConfiguration : EntityTypeConfiguration<Loan>
    {
        public LoanConfiguration()
        {
            ToTable("pret");

            // Composite PK
            HasKey(p => new
            {
                p.BorrowerId,
                p.LibraryItemId
            });

            // SqlException: "The conversion of a datetime2 data type to a datetime data type resulted in an out-of-range value."
            // http://www.mikesdotnetting.com/article/229/conversion-of-a-datetime2-data-type-to-a-datetime-data-type-resulted-in-an-out-of-range-value
            Property(p => p.DateBorrowed)
                .HasColumnName("date_emprunt")
                .HasColumnType("datetime2")
                .HasPrecision(0);

            Property(p => p.DueDate)
                .HasColumnName("date_echeance")
                .HasColumnType("datetime2")
                .HasPrecision(0);

            Property(p => p.DateReturned)
                .HasColumnName("date_retour");

            Property(p => p.BorrowerId)
                .HasColumnName("emprunteur_id");

            Property(p => p.LibraryItemId)
                .HasColumnName("article_id");
        }
    }
}
