using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DAL.Repositories
{
    public class GenericRepository
    {
        public void GenericWayToAddAnEntity<T>(T entity)
            where T : class
        {
            using (var ctx = new Context())
            {
                ctx.Entry(entity).State = EntityState.Added;
                ctx.SaveChanges();
            }
        }

        public void GenericWayToDeleteAnEntity<T>(T entity)
            where T : class
        {
            using (var ctx = new Context())
            {
                ctx.Entry(entity).State = EntityState.Deleted;
                ctx.SaveChanges();
            }
        }
    }
}
