using EF.DAL;
using EF.Domain.Catalogs;
using EF.Domain.Items;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace EF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new Context())
            {
/*
                var borrowers = ctx.Borrowers.ToList();
                Write(borrowers);
                                
                var availableItems = ctx.LibraryItems.Where(i => i.Status == ItemStatus.Available).ToList();
                Write(availableItems);
                             
                // get the first borrower
                var borrower = ctx.Borrowers.Include(b => b.Loans).First();
                Console.WriteLine("First borrower with loan: {0} {1}", borrower.Firstname, borrower.Lastname);
                Console.WriteLine("".PadRight(30, '-'));

                // count number of borrowers
                var borrowersCount = ctx.Database.SqlQuery<int>("SELECT COUNT(0) FROM emprunteur").Single();
                Console.WriteLine("Borrowers count : {0}", borrowersCount);
                Console.WriteLine("".PadRight(30, '-'));

                // find the first DVD
                var dvd = ctx.LibraryItems.OfType<Dvd>().First();
                Console.Write("First DVD: {0}", dvd.ShowProperties());
                Console.WriteLine("".PadRight(30, '-'));

                // use stored procedure
                //                var legacyRepository = new LegacyRepository(ctx);
                //                var borrowersWithDVD = legacyRepository.FindBorrowersWhoOwnsArticlesByType("DVD");

                var borrowerWithAddress = ctx.Borrowers
                                            .Include(b => b.Address)
                                            .First();
                                                
                var loans = ctx.Loans.ToList();
                Write(loans);
*/

                // add a new book
                var myBook = new Book {
                    Author = "Victor Hugo",
                    ISBN = "132132",
                    Language = Language.French,
                    Status = ItemStatus.Available,
                    Title = "Les Misérables",
                    Catalog = new Catalog { Type = CatalogType.General }
                };

                ctx.LibraryItems.Add(myBook);
                ctx.SaveChanges();

                // another way to add a new entity to the context is to change its state to "Added"
                //ctx.Entry<Book>(myBook).State = EntityState.Added;
                //ctx.SaveChanges();
            }

            Console.Read();
        }

        static void Write(IEnumerable<object> objects)
        {
            foreach(var obj in objects)
            {
                Console.WriteLine(obj.ShowProperties());
            }

            Console.WriteLine("".PadRight(30, '-'));
        }
    }
}
