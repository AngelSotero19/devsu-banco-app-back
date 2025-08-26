using banco_api.Application.UseCases.Accounts.Dtos;
using banco_api.Domain.Models;

namespace banco_api.Application.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<string> AddAccountAsync(Account account);
        Task<string> UpdateAccountAsync(Account account);
        Task<IEnumerable<Account>> GetByClientIdAsync(string clientId);
        Task<string> ToggleStatusAsync(AccountToggleRequest client);
        Task<Account> GetByIdAsync(string Id);
        Task<IEnumerable<Account>> GetAllAsync();
    }
}