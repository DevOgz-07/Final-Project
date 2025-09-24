using System.Linq.Expressions;

namespace Final_Project1.Repositories
{
    public interface IRepository<T>
    {
        public IQueryable<T> GetAll();

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression);

        public T GetBy(Expression<Func<T, bool>> expression);

        public void Add(T entity);
        public void Update(T entity);

        public void Update(T entity,params Expression<Func<T, object>>[] expressions);

        public void Delete(T entity);

        
    }
}
