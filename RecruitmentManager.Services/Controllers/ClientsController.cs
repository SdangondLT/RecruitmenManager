using Microsoft.AspNetCore.Mvc;
using RecruitmentManager.Core.Core.V1;
using RecruitmentManager.Entities.DTOs;
using RecruitmentManager.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecruitmentManager.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientCore _clientCore;

        public ClientsController()
        {
            _clientCore = new ClientCore();
        }

        // GET: api/<ClientController>
        [HttpGet]
        public async Task<IEnumerable<Client>> Get()
        {
            return await _clientCore.GetClientsAsync();
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<Client> Post([FromBody] ClientCreateDto client)
        {
            return await _clientCore.CreateClientAsync(client);
        }

        // PUT api/<ClientController>/5
        [HttpPut]
        public async Task<bool> Put([FromBody] Client client)
        {
            return await _clientCore.UpdateClientAsync(client);
        }

        // DELETE api/<ClientController>/5
        [HttpDelete]
        public async Task<bool> Delete(Client client)
        {
            return await _clientCore.DeleteClientAsync(client);
        }
    }
}
