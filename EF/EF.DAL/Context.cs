using EF.DAL.Configuration;
using EF.Domain;
using EF.Domain.Borrower;
using EF.Domain.Items;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

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
            Database.Log = Debug.LogQuery;
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

        //TODO put this method in an appropriate repository
        public IEnumerable<Borrower> FindBorrowersWhoOwnArticles(string typeOfArticle)
        {
            var discriminator = new SqlParameter { ParameterName = "@discriminator", Value = typeOfArticle };
            return Database.SqlQuery<Borrower>("exec FindBorrowerWhoOwnArticles @discriminator", discriminator).ToList();
        }
    }
}