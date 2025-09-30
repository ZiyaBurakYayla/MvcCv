using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MvcCv.Models.Entity;

namespace MvcCv.Repositories
{
    public class GenericRepository<T>  where T : class ,new()
    {
        DbCvEntities1 db = new DbCvEntities1();

        public List<T> List()
        {
            return db.Set<T>().ToList();
        }

        public void TAdd (T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }

        public void TDelete (T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }

        public void TUpdate (T p)
        {
            db.SaveChanges();
        }

        public T TGet (int id)
        {
            return db.Set<T>().Find(id);
        }

        public T Find (Expression<Func<T, bool>> filter)
        {
            //Expression<Func<T, bool>> filter buradaki linq sorgusu ile istenilen şarta göre arama yapmayı sağlar.
            return db.Set<T>().FirstOrDefault(filter);
        }

    }
}