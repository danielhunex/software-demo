using Domain.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Core
{
    public interface IContactService
    {

        Task<Contact> GetByIdAsync(long Id);

        IQueryable<Contact> GetAllAsync();

        Task<bool> SaveAsync(Contact entity);

        Task<bool> DeleteAsync(long Id);
    }
}
