using EF.Domain.Items;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace EF.DAL.Configurations
{
    public class BookConfiguration : EntityTypeConfiguration<Book>
    {
        public BookConfiguration()
        {
            Property(b => b.Author)
                .HasColumnName("auteur")
                .HasMaxLength(50);
                
            Property(b => b.ISBN)
                .HasColumnName("code_isbn")
                .IsRequired()
                .HasMaxLength(13)
                .IsFixedLength();

            Property(b => b.PageCount)
                .HasColumnName("nombre_page");               
        }
    }
}