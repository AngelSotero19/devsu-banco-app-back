using banco_api.Application.UseCases.Clients.Dtos;
using banco_api.Domain.Models;

namespace banco_api.Application.Interfaces.Repositories
{
    public interface IClientRepository
    {
        Task<string> AddClientAsync(Client client);
        Task<string> UpdateClientAsync(ClientDto client);
        Task<string> ToggleStatusAsync(ClientToggleRequest client);
        Task<Client> GetByIdIncludePersonAsync(string Id);
        Task<IEnumerable<Client>> GetAllIncludePersonAsync();
        Task<Client> GetByIdAsync(string Id);
        Task<IEnumerable<Client>> GetAllAsync();
    }
}