using Final_Project1.Areas.admin.ViewsModel;
using Final_Project1.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Final_Project1.Repositories
{
    public class DATARepository<T> : IRepository<T> where T : class
    {
        DataContext db;
        public DATARepository(DataContext _db)
        {
            db = _db;
        }
        public IQueryable<T> GetAll()
        {
            return db.Set<T>();
        }

        public IQueryable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return db.Set<T>().Where(expression);
        }

        public T GetBy(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return db.Set<T>().FirstOrDefault(expression);

        }

        public void Add(T entity)
        {

            db.Add(entity);
            db.SaveChanges();
        }

        public void Delete(T entity)
        {
            db.Remove(entity);
            db.SaveChanges();
        }
        public void Update(T entity)
        {
            db.Update(entity);
            db.SaveChanges();
        }

        public void Update(T entity, params Expression<Func<T, object>>[] expressions)
        {
            if (expressions.Any())
            {
                foreach (var kolon in expressions)
                {
                    db.Entry(entity).Property(kolon).IsModified = true;

                }
            }
            else
            {
                db.Update(entity);
            }
            db.SaveChanges();
        }

        
    }
}
