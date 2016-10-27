using EF.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.DAL.Configurations
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

            // Create a index on a single column, Multiple indexes on a single column, Multi-Column indexes
            // http://stackoverflow.com/questions/22618237/how-to-create-index-in-entity-framework-6-2-with-code-first
            Property(p => p.DateReturned)
                .HasColumnName("date_retour")
                // create a index on a single column
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute())); ;

            Property(p => p.BorrowerId)
                .HasColumnName("emprunteur_id")
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Borrower_Item", 1)
                    {
                        IsUnique = true
                    }));

            Property(p => p.LibraryItemId)
                .HasColumnName("article_id")
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Borrower_Item", 2)
                    {
                        IsUnique = true
                    }));
        }
    }
}
