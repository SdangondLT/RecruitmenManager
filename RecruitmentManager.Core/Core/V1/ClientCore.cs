using Microsoft.EntityFrameworkCore;
using RecruitmentManager.DataAccess.Context;
using RecruitmentManager.Entities.DTOs;
using RecruitmentManager.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruitmentManager.Core.Core.V1
{
    public class ClientCore
    {
        private readonly SqlServerContext _context;

        public ClientCore()
        {
            _context = new SqlServerContext();
        }

        public async Task<List<Client>> GetClientsAsync()
        {
            return await _context.Client.ToListAsync();
        }

        public async Task<Client> CreateClientAsync(ClientCreateDto entity)
        {
            Client newClient = new()
            {
                Name = entity.Name,
                Address = entity.Address,
                Phone = entity.Phone,
            };

            var newClientCreated = _context.Client.Add(newClient);
            await _context.SaveChangesAsync();
            return newClientCreated.Entity;
        }

        //test git
        public async Task<bool> UpdateClientAsync(Client clientToUpdated)
        {
            Client client = _context.Client.Find(clientToUpdated.IdClient);
            client.Name = clientToUpdated.Name;
            client.Address = clientToUpdated.Address;
            client.Phone = clientToUpdated.Phone;

            _context.Client.Update(client);

            int recordsAffeted = await _context.SaveChangesAsync();
            return (recordsAffeted == 1);
        }

        public async Task<bool> DeleteClientAsync(int clientId)
        {
            Client client = _context.Client.Find(clientId);
            _context.Client.Remove(client);
            int recordsAffeted = await _context.SaveChangesAsync();
            return (recordsAffeted == 1);
        }
    }
}
