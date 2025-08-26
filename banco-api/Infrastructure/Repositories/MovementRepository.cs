using banco_api.Application.Interfaces.Repositories;
using banco_api.Domain.Models;
using banco_api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace banco_api.Infrastructure.Repositories
{
    public class MovementRepository : IMovementRepository
    {
        private readonly BancoDBContext _context;

        public MovementRepository(BancoDBContext context)
        {
            _context = context;
        }

        public async Task<string> AddMovementAsync(Movement movement)
        {
            await _context.Movements.AddAsync(movement);
            await _context.SaveChangesAsync();
            return movement.Id;
        }

        public async Task<string> DeleteMovementAsync(Movement movement)
        {
            await _context.Movements.Where(m => m.Id == movement.Id)
                                    .ExecuteDeleteAsync();
            return movement.Id;
        }

        public async Task<IEnumerable<Movement>> GetAllAsync()
        {
            return await _context.Movements
                .Include(m => m.Account)
                .ToListAsync();
        }

        public async Task<IEnumerable<Movement>> GetByAccountIdAsync(string accountId)
        {
            return await _context.Movements
                .Where(m => m.AccountId == accountId)
                .Include(m => m.Account)               
                .ThenInclude(a => a.AccountType)       
                .Include(m => m.Account.Client)        
                .OrderByDescending(m => m.Date)
                .ToListAsync();
        }

        public async Task<Movement> GetByIdAsync(string Id)
        {
            return await _context.Movements.FindAsync(Id);
        }

        public async Task<decimal> GetDebitsByDay(string accountId, DateTime date)
        {
            return await _context.Movements
                .Where(m => m.AccountId == accountId
                         && m.MovementType == "DEBITO"
                         && m.Date.HasValue
                         && m.Date.Value.Date == date.Date)
                .SumAsync(m => m.Value ?? 0);
        }

        public async Task<IEnumerable<Movement>> GetByClientAndDateRangeAsync(string clientId, DateTime start, DateTime end)
        {
            var from = start.Date;
            var to = end.Date.AddDays(1).AddTicks(-1);

            return await _context.Movements
                        .Include(m => m.Account)
                            .ThenInclude(a => a.Client)
                                .ThenInclude(c => c.Person)
                        .Where(m => m.Account.ClientId == clientId
                                 && m.Date >= from
                                 && m.Date <= to)
                        .OrderBy(m => m.Date)
                        .AsNoTracking()
                        .ToListAsync();

        }


        public async Task<string> UpdateMovementAsync(Movement movement)
        {
            _context.Movements.Update(movement);
            await _context.SaveChangesAsync();
            return movement.Id;
        }
    }
}
