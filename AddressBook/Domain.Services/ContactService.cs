using Domain.Core;
using Domain.Core.Models;
using Domain.Repositories;
using System.Threading.Tasks;
using System.Linq;

namespace Domain.Services
{
    public class ContactService : IContactService
    {
        private IRepository<Contact> _contactRepository;
        public ContactService(IRepository<Contact> contactRepositry)
        {
            _contactRepository = contactRepositry;
        }
        public async Task<bool> DeleteAsync(long id)
        {
            return await _contactRepository.DeleteAsync(id);
        }

        public IQueryable<Contact> GetAllAsync()
        {
            return _contactRepository.GetAll();
        }

        public async Task<Contact> GetByIdAsync(long id)
        {
            return await _contactRepository.GetByIdAsync(id);
        }

        public async Task<bool> SaveAsync(Contact entity)
        {
            return await _contactRepository.SaveAsync(entity);
        }
    }
}
