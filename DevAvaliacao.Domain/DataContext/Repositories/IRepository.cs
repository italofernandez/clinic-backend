using System.Linq;

namespace DevAvaliacao.Domain.DataContext.Repositories
{
    public interface IRepository<T> where T : class
    {
        T GetById(int Id);
        IQueryable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Remove(int Id);
    }
}