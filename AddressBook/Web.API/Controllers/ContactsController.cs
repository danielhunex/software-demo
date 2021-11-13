using Domain.Core;
using Domain.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private IContactService _contactService;

        private readonly ILogger<ContactsController> _logger;

        public ContactsController(IContactService contactService, ILogger<ContactsController> logger)
        {
            _logger = logger;
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IEnumerable<Contact>> GetAsync()
        {
            return await _contactService.GetAllAsync().ToListAsync();
        }

        [HttpGet("/{id}")]
        public async Task<Contact> GetByIdAsync(long id)
        {
            return await _contactService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<Contact> PostAsyc([FromBody] Contact contact)
        {
            await _contactService.SaveAsync(contact);
            return contact;
        }
    }
}
