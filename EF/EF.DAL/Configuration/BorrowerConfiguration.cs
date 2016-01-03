using EF.Domain.Borrower;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DAL.Configuration
{
    public class BorrowerConfiguration : EntityTypeConfiguration<Borrower>
    {
        public BorrowerConfiguration()
        {
            ToTable("emprunteur");
            HasKey(b => b.Id);

            Property(b => b.Id).HasColumnName("id");
            Property(b => b.Firstname).HasColumnName("prenom");
            Property(b => b.Lastname).HasColumnName("nom");
            Property(b => b.Age).HasColumnName("age");

            HasOptional(b => b.Address).WithRequired();

            HasMany(b => b.Loans).WithRequired(l => l.Borrower);           
            
            //.IsRequired()
            //.HasMaxLength(8)
            //.IsFixedLength()
            //.HasColumnName("pays")
            //.HasMaxLength(50);
        }
    }
}
