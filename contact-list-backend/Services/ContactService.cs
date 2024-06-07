using contact_list_backend.Data;
using contact_list_backend.Models;
using contact_list_backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace contact_list_backend.Services
{
    public class ContactService : IContactService
    {
        private readonly AppDbContext _context;

        public ContactService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> CreateContactAsync(Contact contact)
        {
            if (contact.Id != 0)
                throw new ArgumentException("New contact cannot have an Id");

            if (await _context.ContactFrequencies.FirstOrDefaultAsync(c => c.Id == contact.ContactFrequencyId) == null)
                throw new ArgumentException("Unknown contact frequency id");

            contact.Address.State = contact.Address.State.ToUpper();
            if (await _context.States.FirstOrDefaultAsync(s => s.Abbreviation == contact.Address.State) == null)
                throw new ArgumentException("Unknown state abbreviation");

            _context.Add(contact);
            await _context.SaveChangesAsync();

            return contact;
        }

        public async Task<Contact> UpdateContactAsync(Contact contact)
        {
            if (contact.Id == 0)
                throw new ArgumentException("Contact requires an Id");

            if (!await _context.Contacts.AnyAsync(c => c.Id == contact.Id))
                throw new ArgumentException("Contact not found");

            if (await _context.ContactFrequencies.FirstOrDefaultAsync(c => c.Id == contact.ContactFrequencyId) == null)
                throw new ArgumentException("Unknown contact frequency id");

            contact.Address.State = contact.Address.State.ToUpper();
            if (await _context.States.FirstOrDefaultAsync(s => s.Abbreviation == contact.Address.State) == null)
                throw new ArgumentException("Unknown state abbreviation");

            _context.Update(contact);
            await _context.SaveChangesAsync();

            return contact;
        }

        public async Task<int> DeleteContactAsync(int id)
        {
            if (id == 0)
                throw new ArgumentException("An Id is required");

            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
                throw new ArgumentException($"Contact not found with Id {id}");

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<IEnumerable<ContactFrequency>> GetContactFrequenciesAsync()
        {
            return await _context.ContactFrequencies.ToListAsync();
        }
    }
}
