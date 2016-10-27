using EF.Domain.Borrowers;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace EF.DAL.Configurations
{
    public class BorrowerConfiguration : EntityTypeConfiguration<Borrower>
    {
        public BorrowerConfiguration()
        {
            ToTable("emprunteur");

            HasKey(b => b.Id);

            Property(b => b.Id)
                .HasColumnName("id");

            Property(b => b.Firstname)
                .HasColumnName("prenom")
                .HasMaxLength(50)
                .IsRequired();

            Property(b => b.Lastname)
                .HasColumnName("nom")
                .HasMaxLength(50)
                .IsRequired();

            Property(b => b.Age)
                .HasColumnName("age")
                .IsOptional();

            // one-to-zero or one relationship
            // http://www.entityframeworktutorial.net/code-first/configure-one-to-one-relationship-in-code-first.aspx
            // PK becomes a FK in another table
            HasOptional(b => b.Address)
                .WithRequired();

            // one-to-many relationship
            HasMany(b => b.Loans)
                .WithRequired(l => l.Borrower)
                .HasForeignKey(b => b.BorrowerId);            
        }
    }
}