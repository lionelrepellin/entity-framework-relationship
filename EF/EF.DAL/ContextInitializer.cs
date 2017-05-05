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
	public class ContextInitializer
	{
		public void Seed(Context context)
		{
			#region Catalogs

			var catalogGeneral = new Catalog(CatalogType.General);
			context.Catalogs.Add(catalogGeneral);

			var catalogOther = new Catalog(CatalogType.Other);
			context.Catalogs.Add(catalogOther);

			#endregion

			#region Borrowers

			var borrower1 = new Borrower
			(
				firstname: "raoul",
				lastname: "duchmol",
				age: 21,
				address: new Address
				(
					street: "impasse",
					zip: "38000",
					city: "Grenoble",
					country: "France"
				)
			);
			context.Borrowers.Add(borrower1);

			var borrower2 = new Borrower
			(
				firstname: "bob",
				lastname: "leponge",
				age: 8
			);
			context.Borrowers.Add(borrower2);

			#endregion

			#region Genres

			var action = new Genre("Action");
			var animation = new Genre("Animation");
			var biography = new Genre("Biography");
			var comedy = new Genre("Comedy");
			var drama = new Genre("Drama");
			var music = new Genre("Music");
			var thriller = new Genre("Thriller");
			var western = new Genre("Western");

			context.Genres.AddRange(new List<Genre>
			{
				action, animation, biography, comedy,
				drama, music, thriller, western
			});

			#endregion

			#region Items

			var book1 = new Book
			(
				status: ItemStatus.Loaned,
				language: Language.French,
				title: "EF for noobs and I",
				author: "Just me",
				isbn: "3126450305604",
				catalog: catalogGeneral
			);
			context.LibraryItems.Add(book1);

			var dvd1 = new Dvd
			(
				status: ItemStatus.Loaned,
				language: Language.Dutch,
				duration: 180,
				summary: "il était une fois...",
				title: "Dans l'ouest il se passe des trucs",
				catalog: catalogGeneral,
				genres: new List<Genre> { western, drama }
			);
			context.LibraryItems.Add(dvd1);

			var dvd2 = new Dvd
			(
				status: ItemStatus.Available,
				language: Language.Spanish,
				duration: 120,
				summary: "bla bla bla",
				title: "Le titre",
				catalog: catalogGeneral,
				genres: new List<Genre> { comedy }
			);
			context.LibraryItems.Add(dvd2);

			var cd1 = new Cd
			(
				artist: "Iron Maiden",
				language: Language.English,
				status: ItemStatus.Available,
				title: "Fear of the dark",
				trackNumber: 14,
				catalog: catalogGeneral
			);
			context.LibraryItems.Add(cd1);

			#endregion

			#region Loans

			var loan1 = new Loan
			(
				borrower: borrower1,
				dueDate: DateTime.Now.AddDays(5),
				libraryItem: book1
			);
			context.Loans.Add(loan1);

			var loan2 = new Loan
			(
				borrower: borrower2,
				dueDate: DateTime.Now.AddDays(3),
			   libraryItem: dvd1
			);
			context.Loans.Add(loan2);

			var loan3 = new Loan
			(
				borrower: borrower1,
				dueDate: DateTime.Now.AddDays(5),
				libraryItem: cd1
			);
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
		}
	}
}