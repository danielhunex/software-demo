using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync(long id);

        IQueryable<T> GetAll();

        Task<bool> SaveAsync(T entity);

        Task<bool> DeleteAsync(long id);
    }
}
