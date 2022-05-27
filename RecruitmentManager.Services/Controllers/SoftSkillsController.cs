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
    public class SoftSkillsController : ControllerBase
    {
        private readonly SoftSkillCore _softSkillCore;

        public SoftSkillsController()
        {
            _softSkillCore = new SoftSkillCore();

        }
        // GET: api/<SoftSkillsController>
        [HttpGet]
        public async Task<IEnumerable<SoftSkill>> Get()
        {
            return await _softSkillCore.GetSoftSkillsAsync();
        }

        // POST api/<SoftSkillsController>
        [HttpPost]
        public async Task<SoftSkill> Post([FromBody] SoftSkillCreateDTO softSkill)
        {
            return await _softSkillCore.CreateSoftSkillAsync(softSkill);
        }

        // PUT api/<SoftSkillsController>/5
        [HttpPut]
        public async Task<bool> Put(int id, [FromBody] SoftSkill softSkill)
        {
            return await _softSkillCore.UpdateSoftSkillAsync(softSkill);
        }

        // DELETE api/<SoftSkillsController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _softSkillCore.DeleteSoftSkillAsync(id);
        }
    }
}
