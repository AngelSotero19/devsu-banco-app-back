using banco_api.Domain.Models;

namespace banco_api.Application.Interfaces.Repositories
{
    public interface IMovementRepository
    {
        Task<string> AddMovementAsync(Movement movement);
        Task<string> UpdateMovementAsync(Movement movement);
        Task<string> DeleteMovementAsync(Movement movement);
        Task<IEnumerable<Movement>> GetByAccountIdAsync(string accountId);
        Task<Movement> GetByIdAsync(string Id);
        Task<IEnumerable<Movement>> GetAllAsync();
        Task<decimal> GetDebitsByDay(string accountId, DateTime date);
        Task<IEnumerable<Movement>> GetByClientAndDateRangeAsync(string clientId, DateTime start, DateTime end);
    }
}