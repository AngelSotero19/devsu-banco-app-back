using banco_api.Domain.Models;

namespace banco_api.Application.Interfaces.Repositories
{
    public interface IAccountTypeRepository
    {
        Task<AccountType> GetByIdAsync(string id);
        Task<IEnumerable<AccountType>> GetAllAsync();
    }
}
