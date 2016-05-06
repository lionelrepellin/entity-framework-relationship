using EF.Domain.Borrowers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EF.DAL.Repositories
{
    public class LegacyRepository
    {
        private Context _context;

        public LegacyRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<Borrower> FindBorrowersWhoOwnsArticlesByType(string typeOfArticle)
        {
            var discriminator = new SqlParameter { ParameterName = "@discriminator", Value = typeOfArticle };
            return _context.Database.SqlQuery<Borrower>("exec FindBorrowersWhoOwnsArticles @discriminator", discriminator).ToList();
        }
    }
}