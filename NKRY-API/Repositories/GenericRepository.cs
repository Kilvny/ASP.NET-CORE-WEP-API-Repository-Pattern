using NKRY_API.DataAccess.EFCore;
using NKRY_API.Domain.Contracts;
using System.Linq.Expressions;

namespace NKRY_API.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class 
    {
        protected ApplicationContext _applicationContext { get; set; }
        public GenericRepository(ApplicationContext applicationContext) 
        {
            _applicationContext = applicationContext;
        }
        public T? GetById(int id)
        {
            return _applicationContext.Set<T>()
                                      .Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _applicationContext.Set<T>().ToList();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _applicationContext.Set<T>().Where(expression);
        }

        public void Create(T entity)
        {
            _applicationContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            _applicationContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            _applicationContext.Set<T>().Remove(entity);
        }
    }
}
