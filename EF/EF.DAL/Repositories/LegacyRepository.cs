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
            if (context == null)
                throw new ArgumentNullException("context");

            _context = context;
        }

        [Obsolete("Prefer mapping instead of stored procedure")]
        public IEnumerable<Borrower> FindBorrowersWhoOwnsArticlesByType(string typeOfArticle)
        {
            var discriminator = new SqlParameter { ParameterName = "@discriminator", Value = typeOfArticle };
            return _context.Database.SqlQuery<Borrower>("exec FindBorrowersWhoOwnsArticles @discriminator", discriminator).ToList();
        }
    }
}