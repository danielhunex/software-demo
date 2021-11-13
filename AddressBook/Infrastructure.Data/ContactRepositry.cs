using Domain.Core.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ContactRepositry : IRepository<Contact>
    {
        private AddressBookContext _context;
        public ContactRepositry(AddressBookContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var contact = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            _context.Contacts.Remove(contact);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public IQueryable<Contact> GetAll()
        {
            return _context.Contacts.AsQueryable();
        }

        public async Task<Contact> GetByIdAsync(long id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> SaveAsync(Contact entity)
        {
            if (entity.Id != 0)
            {
                var toBeUpdated = _context.Contacts.FirstOrDefault(x => x.Id == entity.Id);
                _context.Contacts.Remove(toBeUpdated);
            }
            _context.Contacts.Add(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
