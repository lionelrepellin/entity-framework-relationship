using EF.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DAL.Repositories
{
    public class GenreRepository
    {
        // load a genre inside a context
        public Genre FindById(int id)
        {
            using (var ctx = new Context())
            {
                return ctx.Genres.Single(g => g.Id == id);
            }
        }

        // modify description
        public void Update(Genre genre, string description)
        {
            using (var ctx = new Context())
            {
                // this will not work !
                // 'genre' entity was loaded outside from this context
                genre.SetDescription(description);
                ctx.SaveChanges();
            }
        }

        [Obsolete("Use FindById to avoid duplicated code like: Single(g => g.Id == id)")]
        public void FindAndUpdate(int id, string description)
        {
            using (var ctx = new Context())
            {
                // load 'genre' entity
                var genre = ctx.Genres.Single(g => g.Id == id);

                // modify description
                genre.SetDescription(description);
                ctx.SaveChanges();
            }
        }

        public void UpdateByChangingEntityStatusFirstWay(Genre genre, string description)
        {
            using (var ctx = new Context())
            {
                genre.SetDescription(description);

                // attach the updated entity to the context 
                // and change his status
                ctx.Entry(genre).State = EntityState.Modified;

                ctx.SaveChanges();
            }
        }

        public void UpdateByChangingEntityStatusSecondWay(Genre genre, string description)
        {
            using (var ctx = new Context())
            {
                genre.SetDescription(description);

                // attach the updated entity to the context 
                ctx.Genres.Attach(genre);

                // and change his status                
                ctx.Entry(genre).State = EntityState.Modified;

                ctx.SaveChanges();
            }
        }        
    }
}
