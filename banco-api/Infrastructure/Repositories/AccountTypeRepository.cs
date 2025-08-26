using banco_api.Application.Interfaces.Repositories;
using banco_api.Domain.Models;
using banco_api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace banco_api.Infrastructure.Repositories
{
    public class AccountTypeRepository : IAccountTypeRepository
    {
        private readonly BancoDBContext _context;

        public AccountTypeRepository(BancoDBContext context)
        {
            _context = context;
        }

        public async Task<AccountType> GetByIdAsync(string id)
        {
            return await _context.AccountTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<AccountType>> GetAllAsync()
        {
            return await _context.AccountTypes.ToListAsync();
        }
    }
}
