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
    public class RecruitersController : ControllerBase
    {
        private readonly RecruiterCore _RecruiterCore;

        public RecruitersController()
        {
            _RecruiterCore = new RecruiterCore();
        }

        // GET: api/<RecruitersController>
        [HttpGet]
        public async Task<IEnumerable<Recruiter>> Get()
        {
            return await _RecruiterCore.GetRecruiters();
        }

        // GET api/<RecruitersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RecruitersController>
        [HttpPost]
        public async Task<Recruiter> Post([FromBody] RecruiterCreateDto recruiter)
        {
            return await _RecruiterCore.CreateRecruiter(recruiter);
        }

        // PUT api/<RecruitersController>/5
        [HttpPut]
        public async Task<bool> Put([FromBody] Recruiter recruiter)
        {
            return await _RecruiterCore.UpdateRecruiter(recruiter);
        }

        // DELETE api/<RecruitersController>/5
        [HttpDelete("{id}")]
        public async Task<IEnumerable<Recruiter>> Delete(int id)
        {
            return await _RecruiterCore.DeleteRecruiter(id);
        }
    }
}
