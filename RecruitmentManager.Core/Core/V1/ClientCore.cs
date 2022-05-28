
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecruitmentManager.Core.Core.ErrorsHandler;
using RecruitmentManager.DataAccess.Context;
using RecruitmentManager.Entities.DTOs;
using RecruitmentManager.Entities.Entities;
using RecruitmentManager.Entities.Utils;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace RecruitmentManager.Core.Core.V1
{
    public class ClientCore
    {
        private readonly SqlServerContext _context;
        private readonly ILogger<Client> _logger;
        private readonly ErrorHandler<Client> _errorHandler;
        private readonly IMapper _mapper;

        public ClientCore(ILogger<Client> logger, IMapper mapper, SqlServerContext context)
        {
            _logger = logger;
            _errorHandler = new ErrorHandler<Client>(logger);
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseService<List<Client>>> GetClientsAsync()
        {
            try
            {
                var response = await _context.Client.ToListAsync();
                return new ResponseService<List<Client>>(false, response.Count == 0 ? "No records found" : $"{response.Count} records found", HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "GetClientAsync", new List<Client>());
            }
        }

        public async Task<ResponseService<Client>> CreateClientAsync(ClientCreateDto entity)
        {
            Client newClient = new();
            newClient = _mapper.Map<Client>(entity);

            try
            {
                var newClientCreated = _context.Client.Add(newClient);
                await _context.SaveChangesAsync();

                return new ResponseService<Client>(false, "Succefully created Client", HttpStatusCode.Created, newClientCreated.Entity);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "CreateClientAsync", new Client());
            }
        }

        public async Task<ResponseService<bool>> UpdateClientAsync(Client clientToUpdate)
        {
            Client client = _mapper.Map<Client>(clientToUpdate);

            try
            {
                _context.Client.Update(client);
                await _context.SaveChangesAsync();
                return new ResponseService<bool>(false, "Succefully Updated Client", HttpStatusCode.OK, true);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "UpdateClientAsync", false);
            }
        }

        public async Task<ResponseService<bool>> DeleteClientAsync(Client clientToDelete)
        {
            Client client = _context.Client.Find(clientToDelete.IdClient);

            try
            {
                _context.Remove(client);
                await _context.SaveChangesAsync();
                return new ResponseService<bool>(false, "Succefully Deleted Client", HttpStatusCode.OK, true);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "DeleteClientAsync", false);
            }
        }
    }
}
