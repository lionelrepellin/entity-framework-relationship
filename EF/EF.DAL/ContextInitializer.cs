using EF.Domain;
using EF.Domain.Borrowers;
using EF.Domain.Items;
using System;
using System.IO;
using System.Collections.Generic;
using System.Data.Entity;
using EF.Domain.Catalogs;

namespace EF.DAL
{
//    public class ContextInitializer : CreateDatabaseIfNotExists<Context>
    public class ContextInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            #region Catalogs

            var catalogGeneral = new Catalog
            {
                Type = CatalogType.General
            };
            context.Catalogs.Add(catalogGeneral);

            var catalogOther = new Catalog
            {
                Type = CatalogType.Other
            };
            context.Catalogs.Add(catalogOther);

            #endregion

            #region Borrowers

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

            #endregion

            #region Genres

            var action = new Genre { Description = "Action" };
            context.Genres.Add(action);

            var animation = new Genre { Description = "Animation" };
            context.Genres.Add(animation);

            var biography = new Genre { Description = "Biography" };
            context.Genres.Add(biography);
            
            var comedy = new Genre { Description = "Comedy" };
            context.Genres.Add(comedy);

            var drama = new Genre { Description = "Drama" };
            context.Genres.Add(drama);

            var music = new Genre { Description = "Music" };
            context.Genres.Add(music);

            var thriller = new Genre { Description = "Thriller" };
            context.Genres.Add(thriller);

            var western = new Genre { Description = "Western" };
            context.Genres.Add(western);
            
            #endregion

            #region Items

            var book1 = new Book
            {
                Status = ItemStatus.Loaned,
                Language = Language.French,
                Title = "EF for noobs and I",
                Author = "Just me",
                ISBN = "3126450305604",
                Catalog = catalogGeneral
            };
            context.LibraryItems.Add(book1);

            var dvd1 = new Dvd
            {
                Status = ItemStatus.Loaned,
                Language = Language.Dutch,
                Duration = 180,
                Summary = "il était une fois...",
                Title = "Dans l'ouest il se passe des trucs",
                Catalog = catalogGeneral,
                Genres = new List<Genre> { western, drama }
            };
            context.LibraryItems.Add(dvd1);

            var dvd2 = new Dvd
            {
                Status = ItemStatus.Available,
                Language = Language.Spanish,
                Duration = 120,
                Summary = "bla bla bla",
                Title = "Le titre",
                Catalog = catalogGeneral,
                Genres = new List<Genre> { comedy }
            };
            context.LibraryItems.Add(dvd2);

            var cd1 = new Cd
            {
                Artist = "Iron Maiden",
                Language = Language.English,
                Status = ItemStatus.Available,
                Title = "Fear of the dark",
                TracksNumber = 14,
                Catalog = catalogGeneral
            };
            context.LibraryItems.Add(cd1);

            #endregion

            #region Loans

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

            #endregion

            #region Stored procedures

            var files = Directory.GetFiles("StoredProcedures", "*.sql");
            foreach (var file in files)
            {
                var content = File.ReadAllText(file);
                context.Database.ExecuteSqlCommand(content);
            }

            #endregion

            context.SaveChanges();

            base.Seed(context);
        }        
    }    
}