using contact_list_backend.Models;

namespace contact_list_backend.Services.Interfaces
{
    public interface IStateService
    {
        Task<IEnumerable<State>> GetStateAsync();
    }
}
