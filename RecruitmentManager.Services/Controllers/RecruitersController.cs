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
        private readonly RecruiterCore _recruiterCore;

        public RecruitersController()
        {
            _recruiterCore = new RecruiterCore();
        }

        // GET: api/<RecruitersController>
        [HttpGet]
        public async Task<IEnumerable<Recruiter>> Get()
        {
            return await _recruiterCore.GetRecruitersAsync();
        }

        // GET api/<RecruitersController>/5
        [HttpGet("{id}")]
        public async Task<Recruiter> Get(int id)
        {
            return await _recruiterCore.GetRecruiterAsync(id);
        }

        // POST api/<RecruitersController>
        [HttpPost]
        public async Task<Recruiter> Post([FromBody] RecruiterCreateDto recruiter)
        {
            return await _recruiterCore.CreateRecruitersAsync(recruiter);
        }

        // PUT api/<RecruitersController>/5
        [HttpPut]
        public async Task<bool> Put([FromBody] Recruiter recruiter)
        {
            return await _recruiterCore.UpdateRecruitersAsync(recruiter);
        }

        // DELETE api/<RecruitersController>/5
        [HttpDelete]
        public async Task<bool> Delete(Recruiter recruiter)
        {
            return await _recruiterCore.DeleteRecruitersAsync(recruiter);
        }
    }
}
