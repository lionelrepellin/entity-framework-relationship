﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.Domain.Items;

namespace EF.DAL.Configuration
{
    public class LibraryItemConfiguration : EntityTypeConfiguration<LibraryItem>
    {
        // POI: because of inheritance you can see Discriminator column in article table
        public LibraryItemConfiguration()
        {
            ToTable("article");
            HasKey(a => a.Id);

            Property(a => a.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.Title).HasColumnName("titre");
            Property(a => a.Status).HasColumnName("statut");
            Property(a => a.Language).HasColumnName("langage");
            Property(a => a.CatalogId).HasColumnName("catalogue_id");

            // one-to-many relationship
            HasMany(a => a.Loans)
                .WithRequired(l => l.LibraryItem)
                .HasForeignKey(l => l.LibraryItemId);
        }
    }
}
