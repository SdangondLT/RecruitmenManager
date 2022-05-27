
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecruitmentManager.Core.Utils;
using RecruitmentManager.DataAccess.Context;
using RecruitmentManager.Entities.DTOs;
using RecruitmentManager.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentManager.Core.Core.V1
{
    public class ClientCore
    {
        private readonly ILogger<Client> _logger;
        public ClientCore(ILogger<Client> logger)
        {
            _logger = logger;
            _context = new SqlServerContext();

        }

        public async Task<ResponseService<List<Client>>> GetClientsAsync()
        {
            try
            {
                var response = await _context.Client.ToListAsync();

                return new ResponseService<List<Client>>(false, response.Count == 0 ? "No records found" : $"{response.Count} records found", System.Net.HttpStatusCode.OK, response);

            }
            catch (Exception ex)
            {
                return new ResponseService<List<Client>>(true, $"Error:{ex.Message}", System.Net.HttpStatusCode.InternalServerError, new List<Client>());
            }

        }

        public async Task<ResponseService<Client>> CreateClientAsync(ClientCreateDto entity)
        {
            Client newClient = new();
            newClient.Name = entity.Name;
            newClient.Address = entity.Address;
            newClient.PhoneNumber = entity.PhoneNumber;

            try
            {
                var newClientCreated = _context.Client.Add(newClient);
                await _context.SaveChangesAsync();

                return new ResponseService<Client>(false, "Succefully created Client", HttpStatusCode.Created, newClientCreated.Entity); ;
            }
            catch (Exception ex)
            {
                return new ResponseService<Client>(true, $"Record not created {ex.Message}", HttpStatusCode.InternalServerError, new Client());
            }
        }

        public async Task<bool> UpdateClientAsync(Client clientToUpdated)
        {
            Client client = _context.Client.Find(clientToUpdated.IdClient);
            client.Name = clientToUpdated.Name;
            client.Address = clientToUpdated.Address;
            client.PhoneNumber = clientToUpdated.PhoneNumber;

            _context.Client.Update(client);

            int recordsAffeted = await _context.SaveChangesAsync();

            return (recordsAffeted == 1);
        }

        public async Task<bool> DeleteClientAsync(Client clientToDelete)
        {
            Client client = _context.Client.Find(clientToDelete.IdClient);
           
            _context.Client.Remove(client);

            int recordsAffeted = await _context.SaveChangesAsync();

            return (recordsAffeted == 1);
        }
    }
}
