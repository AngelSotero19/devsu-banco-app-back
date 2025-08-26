using banco_api.Application.Interfaces.Repositories;
using banco_api.Application.UseCases.Clients.Dtos;
using banco_api.Domain.Models;
using banco_api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace banco_api.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly BancoDBContext _context;

        public ClientRepository(BancoDBContext context)
        {
            _context = context;
        }

        public async Task<string> AddClientAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return client.Id;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<IEnumerable<Client>> GetAllIncludePersonAsync()
        {
            return await _context.Clients
            .Include(c => c.Person)
            .ToListAsync();
        }

        public async Task<Client> GetByIdAsync(string Id)
        {
            return await _context.Clients.FindAsync(Id);
        }

        public async Task<Client> GetByIdIncludePersonAsync(string Id)
        {
            return await _context.Clients
            .Include(c => c.Person)
            .FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<string> ToggleStatusAsync(ClientToggleRequest request)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == request.Id);
            client.Status = request.NewStatus;
            await _context.SaveChangesAsync();
            return client.Id;
        }

        public async Task<string> UpdateClientAsync(ClientDto client)
        {
            var person = await _context.Clients.FirstOrDefaultAsync(x => x.Id == client.Id);
            person.Password = client.Password;
            await _context.SaveChangesAsync();
            return client.Id;
        }
    }
}