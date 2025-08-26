using banco_api.Application.Interfaces.Repositories;
using banco_api.Application.UseCases.Clients.Dtos;
using banco_api.Domain.Models;
using banco_api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace banco_api.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly BancoDBContext _context;

        public PersonRepository(BancoDBContext context)
        {
            _context = context;
        }
        public async Task<string> AddPersonAsync(Person person)
        {
            await _context.People.AddAsync(person);
            await _context.SaveChangesAsync();
            return person.Id;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _context.People.ToListAsync();
        }

        public async Task<Person> GetByIdAsync(string Id)
        {
            return await _context.People.FindAsync(Id);
        }

        public async Task<string> UpdatePersonAsync(ClientDto client)
        {
            var person = await _context.People.FirstOrDefaultAsync(x => x.Id == client.PersonId);
            person.Address = client.Address;
            person.Gender = client.Gender;
            person.Phone = client.Phone;
            person.Age = client.Age;
            person.Credential = client.Credential;
            person.Name = client.Name;
            await _context.SaveChangesAsync();
            return person.Id;
        }
    }
}
