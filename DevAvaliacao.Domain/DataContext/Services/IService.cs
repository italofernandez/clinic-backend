using System.Collections.Generic;
using DevAvaliacao.Domain.DataContext.Models;

namespace DevAvaliacao.Domain.DataContext.Services
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll();
        ResponseModel GetWithPagination(int pageSize, int pageNumber);
        ResponseModel GetWithFilters(T entity);
        ResponseModel GetWithFiltersAndPagination(int pageSize, int pageNumber, T entity = null);
        ResponseModel GetById(int Id);
        ResponseModel Save(T entity);
        ResponseModel Update(T entity);
        ResponseModel Remove(int Id);
    }
}