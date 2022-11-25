using ETrade.Dal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Core
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        TradeContext _db;

        public BaseRepository(TradeContext db)
        {
            _db = db;
        }
        public bool Add(T entity)
        {

            try
            {
                Set().Add(entity);

                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Delete(T entity)
        {

            try
            {
                Set().Remove(entity);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id, int id2)
        {
            try
            {
                Set().Remove(Find(id,id2));

                return true;
            }
            catch
            {
                return false;
            }
        }

        public T Find(int Id)
        {
            return Set().Find(Id);
        }

        public T Find(int id, int id2)
        {
            return Set().Find(id,id2);
        }

        public List<T> List()
        {
            // _db.Set<T>().ToList(); bunu yazmamak için set dedik
            return Set().ToList();
        }



        public DbSet<T> Set()
        {
            return _db.Set<T>();
        }

        public bool Update(T entity)
        {
            try
            {
                Set().Update(entity);
                return true;
            }
            catch
            {
                return false;
            }

        }

    }
}
