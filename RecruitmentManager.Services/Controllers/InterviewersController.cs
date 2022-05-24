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
    public class InterviewersController : ControllerBase
    {
        private readonly InterviewerCore _interviewerCore;

        public InterviewersController()
        {
            _interviewerCore = new InterviewerCore();
        }
        // GET: api/<InterviewersController>
        [HttpGet]
        public async Task<IEnumerable<Interviewer>> Get()
        {
            return await _interviewerCore.GetInterviewersAsync();
        }

        // POST api/<InterviewersController>
        [HttpPost]
        public async Task<Interviewer> Post([FromBody] InterviewerCreateDTO interviewer)
        {
            return await _interviewerCore.CreateInterviewerAsync(interviewer);
        }

        // PUT api/<InterviewersController>/5
        [HttpPut]
        public async Task<bool> Put(int id, [FromBody] Interviewer interviewer)
        {
            return await _interviewerCore.UpdateInterviewerAsync(interviewer);
        }

        // DELETE api/<InterviewersController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _interviewerCore.DeleteInterviewerAsync(id);
        }
    }
}
