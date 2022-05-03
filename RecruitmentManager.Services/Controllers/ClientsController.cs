using Microsoft.AspNetCore.Mvc;
using RecruitmentManager.Core.Core.V1;
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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
