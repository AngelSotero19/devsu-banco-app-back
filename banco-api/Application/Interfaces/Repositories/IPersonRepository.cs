using banco_api.Application.UseCases.Clients.Dtos;
using banco_api.Domain.Models;

namespace banco_api.Application.Interfaces.Repositories
{
    public interface IPersonRepository
    {
        Task<string> AddPersonAsync(Person person);
        Task<string> UpdatePersonAsync(ClientDto person);
        Task<Person> GetByIdAsync(string Id);
        Task<IEnumerable<Person>> GetAllAsync();
    }
}
