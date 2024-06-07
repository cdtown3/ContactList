using contact_list_backend.Models;

namespace contact_list_backend.Services.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetContactsAsync();
        Task<Contact> CreateContactAsync(Contact contact);
        Task<Contact> UpdateContactAsync(Contact contact);
        Task<int> DeleteContactAsync(int id);
        Task<IEnumerable<ContactFrequency>> GetContactFrequenciesAsync();
    }
}
