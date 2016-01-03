using EF.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DAL.Configuration
{
    public class LoanConfiguration : EntityTypeConfiguration<Loan>
    {
        public LoanConfiguration()
        {
            ToTable("pret");
            HasKey(p => new
            {
                p.BorrowerId,
                p.LibraryItemId
            });
            
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
