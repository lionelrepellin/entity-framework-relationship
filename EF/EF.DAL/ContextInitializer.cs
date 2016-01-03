using EF.Domain;
using EF.Domain.Borrower;
using EF.Domain.Items;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DAL
{
//    public class ContextInitializer : CreateDatabaseIfNotExists<Context>
    public class ContextInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            var catalog = new Catalog
            {
                Type = CatalogType.General
            };
            context.Catalogs.Add(catalog);
            //context.SaveChanges();

            var borrower1 = new Borrower
            {
                Firstname = "raoul",
                Lastname = "duchmol",
                Age = 21,
                Address = new Address
                {
                    Street = "impasse",
                    Zip = "38000",
                    City = "Grenoble",
                    Country = "France"
                }
            };
            context.Borrowers.Add(borrower1);

            var borrower2 = new Borrower
            {
                Firstname = "bob",
                Lastname = "leponge",
                Age = 8                
            };
            context.Borrowers.Add(borrower2);

            var book1 = new Book
            {
                Status = ItemStatus.Loaned,
                Language = Language.French,
                Title = "EF for noobs and I",
                Author = "Just me",
                ISBN = "312645030560465146",
                Catalog = catalog
            };
            context.LibraryItems.Add(book1);

            var dvd1 = new DVD
            {
                Status = ItemStatus.Loaned,
                Language = Language.Dutch,
                Duration = 180,
                Summary = "il était une fois...",
                Title = "Dans l'ouest il se passe des trucs",
                Catalog = catalog
            };
            context.LibraryItems.Add(dvd1);

            var dvd2 = new DVD
            {
                Status = ItemStatus.Available,
                Language = Language.Spanish,
                Duration = 120,
                Summary = "bla bla bla",
                Title = "Le titre",
                Catalog = catalog
            };
            context.LibraryItems.Add(dvd2);

            var cd1 = new CD
            {
                Artist = "Iron Maiden",
                Language = Language.English,
                Status = ItemStatus.Available,
                Title = "Fear of the dark",
                TracksNumber = 14,
                Catalog = catalog
            };
            context.LibraryItems.Add(cd1);

            var loan1 = new Loan
            {
                Borrower = borrower1,
                DateBorrowed = DateTime.Now,
                DueDate = DateTime.Now.AddDays(5),
                LibraryItem = book1
            };
            context.Loans.Add(loan1);

            var loan2 = new Loan
            {
                Borrower = borrower2,
                DateBorrowed = DateTime.Now,
                DueDate = DateTime.Now.AddDays(3),
                LibraryItem = dvd1
            };
            context.Loans.Add(loan2);

            var loan3 = new Loan
            {
                Borrower = borrower1,
                DateBorrowed = DateTime.Now,
                DueDate = DateTime.Now.AddDays(5),
                LibraryItem = cd1
            };
            context.Loans.Add(loan3);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
