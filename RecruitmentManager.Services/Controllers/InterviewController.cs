using Microsoft.AspNetCore.Mvc;
using RecruitmentManager.Core.Core.V1;
using RecruitmentManager.Entities.DTOs;
using RecruitmentManager.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecruitmentManager.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        private readonly InterviewCore _interviewCore;

        public InterviewController()
        {
            _interviewCore = new InterviewCore();
        }
        // GET: api/<InterviewController>
        [HttpGet]
        public async Task<IEnumerable<Interview>> Get()
        {
            return await _interviewCore.GetInterviewsAsync();
        }

        // GET api/<InterviewController>/5
        [HttpGet("{id}")]
        public async Task<Interview> Get(int id)
        {
            return await _interviewCore.GetInterviewAsync(id);
        }

        // POST api/<InterviewController>
        [HttpPost]
        public async Task<Interview> Post([FromBody] InterviewCreateDto interview)
        {
            return await _interviewCore.CreateInterviewAsync(interview);
        }

        // PUT api/<InterviewController>/5
        [HttpPut]
        public async Task<bool> Put([FromBody] Interview interview)
        {
            return await _interviewCore.UpdateInterviewAsync(interview);
        }

        // DELETE api/<InterviewController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _interviewCore.DeleteInterviewAsync(id);        
        }
    }
}
