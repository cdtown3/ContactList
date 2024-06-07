using contact_list_backend.Data;
using contact_list_backend.Models;
using contact_list_backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace contact_list_backend.Services
{
    public class StateService : IStateService
    {
        private readonly AppDbContext _context;

        public StateService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<State>> GetStateAsync()
        {
            return await _context.States.ToListAsync();
        }
    }
}
