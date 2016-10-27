using EF.DAL.Configurations;
using EF.Domain;
using EF.Domain.Catalogs;
using EF.Domain.Borrowers;
using EF.Domain.Items;
using System.Collections.Generic;
using System.Data.Entity;

namespace EF.DAL
{
    public class Context : DbContext
    {
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<LibraryItem> LibraryItems { get; set; }
        public DbSet<Loan> Loans { get; set; }

        static Context()
        {
            Database.SetInitializer<Context>(new ContextInitializer());
        }

        public Context()
            : base("MainDatabaseContext")
        {

#if DEBUG
            Database.Log = (msg) => System.Diagnostics.Debug.WriteLine(msg);
#else
            Database.Log = Debug.LogQuery;
#endif

            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // borrower
            modelBuilder.Configurations.Add(new BorrowerConfiguration());
            modelBuilder.Configurations.Add(new BorrowerAddressConfiguration());

            // catalog
            modelBuilder.Configurations.Add(new CatalogConfiguration());

            // genres
            modelBuilder.Configurations.Add(new GenreConfiguration());

            // library items
            modelBuilder.Configurations.Add(new LibraryItemConfiguration());
            modelBuilder.Configurations.Add(new BookConfiguration());
            modelBuilder.Configurations.Add(new DvdConfiguration());
            modelBuilder.Configurations.Add(new CdConfiguration());

            // loan
            modelBuilder.Configurations.Add(new LoanConfiguration());

            base.OnModelCreating(modelBuilder);
        }        
    }
}