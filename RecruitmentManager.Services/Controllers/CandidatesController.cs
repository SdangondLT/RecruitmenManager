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
    public class CandidatesController : ControllerBase
    {
        private readonly CandidateCore _candidateCore;

        public CandidatesController()
        {
            _candidateCore = new CandidateCore();
        }

        // GET: api/<CandidatesController>
        [HttpGet]
        public async Task<IEnumerable<Candidate>> Get()
        {
            return await _candidateCore.GetClientsAsync();
        }

        // GET api/<CandidatesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CandidatesController>
        [HttpPost]
        public async Task<Candidate> Post([FromBody] CandidateCreateDto candidate)
        {
            return await _candidateCore.CreateCandidateAsync(candidate);
        }

        // PUT api/<CandidatesController>/5
        [HttpPut]
        public async Task<bool> Put([FromBody] Candidate candidate)
        {
            return await _candidateCore.UpdateCandidateAsync(candidate);
        }

        // DELETE api/<CandidatesController>/5
        [HttpDelete]
        public async Task<bool> Delete([FromBody] Candidate candidate)
        {
            return await _candidateCore.DeleteCandidateAsync(candidate);
        }
    }
}
