using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class CandidatesController : ControllerBase
    {
        private readonly CandidateCore _candidateCore;

        public CandidatesController()
        {
            _candidateCore = new CandidateCore();
        }

        // GET: api/<CandidatesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidate>>> Get()
        {
            var response = await _candidateCore.GetCandidateAsync();
            return StatusCode((int)response.StatusHttp, response);
        }

        // GET api/<CandidatesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CandidatesController>
        [HttpPost]
        public async Task<ActionResult<Client>> Post([FromBody] CandidateCreateDto candidate)
        {
            var response = await _candidateCore.CreateCandidateAsync(candidate);
            return StatusCode((int)response.StatusHttp, response);
        }

        // PUT api/<CandidatesController>/5
        [HttpPut]
        public async Task<bool> Put([FromBody] Candidate candidate)
        {
            return await _candidateCore.UpdateCandidateAsync(candidate);
        }

        // DELETE api/<CandidatesController>/5
        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            return await _candidateCore.DeleteCandidateAsync(id);
        }
    }
}
