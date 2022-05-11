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
    public class SoftKillsController : ControllerBase
    {
        private readonly SoftSkillCore _softSkillCore;

        public SoftKillsController()
        {
            _softSkillCore = new SoftSkillCore();
        }

        // GET: api/<SoftKillsController>
        [HttpGet]
        public async Task<IEnumerable<SoftSkill>> Get()
        {
            return await _softSkillCore.GetSoftKillsAsync();
        }

        // POST api/<SoftKillsController>
        [HttpPost]
        public async Task<SoftSkill> Post([FromBody] SoftSkillCreateDto softSkill)
        {
            return await _softSkillCore.CreateSoftSkillAsync(softSkill);
        }

        // PUT api/<SoftKillsController>/5
        [HttpPut]
        public async Task<bool> Put([FromBody] SoftSkill softSkill)
        {
            return await _softSkillCore.UpdateSoftSkillAsync(softSkill);
        }

        // DELETE api/<SoftKillsController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int softSkillId)
        {
            return await _softSkillCore.DeleteSoftSkillAsync(softSkillId);
        }
    }
}
