using EF.DAL;
using EF.Domain;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                //Write<Borrower>(borrowers);

                var items = ctx.Catalogs
                                    .Where(c => c.Type == CatalogType.General)
                                    .Select(c => c.Items.OfType<Book>())
                                    .ToList();
                                    */


                //Console.WriteLine("".PadRight(30,'-'));
                /*
                var availableItems = ctx.LibraryItems.Where(i => i.Status == ItemStatus.Available).ToList();
                Write<LibraryItem>(availableItems);

                Console.WriteLine("".PadRight(30, '-'));
                
                //var borrower = ctx.Borrowers.Include(b => b.Loans).First();
                */
                

                var borrower = ctx.Borrowers
                                    //.Include(b => b.Address)
                                    .First();
                //.Select(b => b.Loans).Select(c => c.)
                //.Select(c => c.Select(a => a.Borrower))


                /*
                var borrowerFull = ctx.Loans
                                        //.Include(a => a.LibraryItem)                    
                                        .Where(l => l.BorrowerId == borrower.Id).First();

                */
                Console.WriteLine(borrower.ShowProperties());
                /*
                if(borrower.Loans != null && borrower.Loans.Count() > 0)
                {
                    var loan = borrower.Loans.First();
                    Console.WriteLine(loan);

                    if(loan.Borrower != null)
                    {
                        Console.WriteLine(loan.Borrower);
                    }
                }
                */


                //var book = ctx.LibraryItems.OfType<Book>().First();
                //Console.WriteLine(book);

                Console.WriteLine("".PadRight(30, '-'));
                /*
                var loans = ctx.Loans.ToList();
                Write<Loan>(loans);

                Console.WriteLine("".PadRight(30, '-'));
                */

            }
            
            Console.Read();
        }

        static void Write<T>(IEnumerable<T> objs)
        {
            foreach(var o in objs)
            {
                Console.WriteLine(o.ShowProperties());
            }
        }
    }
}
