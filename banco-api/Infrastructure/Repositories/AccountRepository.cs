using banco_api.Application.Interfaces.Repositories;
using banco_api.Application.UseCases.Accounts.Dtos;
using banco_api.Domain.Models;
using banco_api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace banco_api.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BancoDBContext _context;

        public AccountRepository(BancoDBContext context)
        {
            _context = context;
        }

        public async Task<string> AddAccountAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
            return account.Id;
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _context.Accounts
                .Include(a => a.AccountType)
                .Include(a => a.Client)
                .ThenInclude(a => a.Person).ToListAsync();
        }

        public async Task<IEnumerable<Account>> GetByClientIdAsync(string clientId)
        {
            return await _context.Accounts
                .Include(a => a.AccountType)
                .Include(a => a.Client)
                .ThenInclude(c => c.Person)
                .Where(a => a.ClientId == clientId)
                .ToListAsync();
        }

        public async Task<Account> GetByIdAsync(string Id)
        {
            return await _context.Accounts.FindAsync(Id);
        }

        public async Task<string> ToggleStatusAsync(AccountToggleRequest request)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == request.Id);
            account.Status = request.NewStatus;
            await _context.SaveChangesAsync();
            return account.Id;
        }

        public async Task<string> UpdateAccountAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
            return account.Id;
        }
    }
}