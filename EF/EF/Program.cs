using EF.DAL;
using EF.DAL.Repositories;
using EF.Domain;
using EF.Domain.Items;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using EF.Domain.Catalogs;

namespace EF
{
	class Program
	{
		static void Main(string[] args)
		{
			// seed data
			var initializer = new ContextInitializer();
			initializer.Seed(new Context());

			var genreRepository = new GenreRepository();

			// load a genre inside a context
			var genre = genreRepository.FindById(1);

			// modify the 'genre' entity
			genreRepository.Update(genre, "new description");

			// reload the updated entity
			var updatedGenre = genreRepository.FindById(1);

			// result will be false : the entity has not been updated !
			var updateSuccessful = updatedGenre.Description == genre.Description;
			if (!updateSuccessful)
				throw new Exception("The updatedGenre has not been stored in database, because it was out of context");

			// ---------------------------------------------------------------------------------------

			// 1st (BAD) way: one method to do FindById and Update at the same time
			genreRepository.FindAndUpdate(1, "bla bla bla");

			// ---------------------------------------------------------------------------------------

			// 2nd (GOOD) way: still use FindById method and improve the Update method
			// with playing with entities status
			var secondGenre = genreRepository.FindById(1);

			// attach entity to the context and change his status in one line
			genreRepository.UpdateByChangingEntityStatusFirstWay(secondGenre, "the new description");

			// another way to attach and change the status of the entity - the same as above, in two lines
			//genreRepository.UpdateByChangingEntityStatusSecondWay(secondGenre, "the new description");

			// reload the updated entity
			var reloadSecondGenre = genreRepository.FindById(1);

			// result will be true : the entity has been modified
			updateSuccessful = reloadSecondGenre.Description == secondGenre.Description;
			if (!updateSuccessful)
				throw new Exception("The exception will be never thrown !");

			// ---------------------------------------------------------------------------------------

			// create a new 'genre' from scratch with an existing Id
			var newGenreFromScratch = new Genre(2);

			// update the descritpion
			genreRepository.UpdateByChangingEntityStatusSecondWay(newGenreFromScratch, "Modified");

			var reloadedGenreFromScratch = genreRepository.FindById(2);

			var resultUpdateFromScratch = (newGenreFromScratch.Description == reloadedGenreFromScratch.Description);
			if (!resultUpdateFromScratch)
				throw new Exception("The exception will be never thrown !");

			// ---------------------------------------------------------------------------------------

			// add a new genre with generic repository
			var newGenre = new Genre("Horror");
			var genericRepository = new GenericRepository();
			genericRepository.GenericWayToAddAnEntity(newGenre);

			// load new added genre from GenreRepository
			var newGenreAdded = genreRepository.FindById(newGenre.Id);

			// compare the two loaded entities
			var addResult = (newGenre.Description == newGenreAdded.Description);
			if (!addResult)
				throw new Exception("The exception will be never thrown !");

			genericRepository.GenericWayToDeleteAnEntity(newGenre);

			// ---------------------------------------------------------------------------------------

			// miscellaneous manipulations
			using (var ctx = new Context())
			{
				// retrieve simply all borrowers
				var borrowers = ctx.Borrowers.ToList();

				// retrieve books from General catalog
				var books = ctx.Catalogs
									.Where(c => c.Type == CatalogType.General)
									.Select(c => c.Items.OfType<Book>())
									.ToList();

				// retrieve all available items                
				var availableItems = ctx.LibraryItems
												.Where(i => i.Status == ItemStatus.Available)
												.ToList();

				// the list of borrowers who borrowed an item
				var borrower = ctx.Borrowers
										.Include(b => b.Loans)
										.First();

				// an inline SQL query
				var borrowersCount = ctx.Database.SqlQuery<int>("SELECT COUNT(0) FROM emprunteur").First();

				// all DVD from any catalogs
				var dvd = ctx.LibraryItems.OfType<Dvd>().First();

				// use a stored procedure
				var legacyRepository = new LegacyRepository(ctx);
				var borrowersWithDVD = legacyRepository.FindBorrowersWhoOwnsArticlesByType("DVD");
			}

			Console.WriteLine("The End");
			Console.Read();
		}
	}
}
