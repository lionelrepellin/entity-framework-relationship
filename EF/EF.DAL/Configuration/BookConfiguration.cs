using EF.Domain.Items;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DAL.Configuration
{
    public class BookConfiguration : EntityTypeConfiguration<Book>
    {
        public BookConfiguration()
        {
            Property(b => b.Author).HasColumnName("auteur");
            Property(b => b.ISBN).HasColumnName("code_isbn");
        }
    }
}
