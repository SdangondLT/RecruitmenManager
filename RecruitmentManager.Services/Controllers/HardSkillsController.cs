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
    public class HardSkillsController : ControllerBase
    {
        private readonly HardSkillCore _hardSkillCore;

        public HardSkillsController()
        {
            _hardSkillCore = new HardSkillCore();
        }

        // GET: api/<HardSkillsController>
        [HttpGet]
        public async Task<IEnumerable<HardSkill>> Get()
        {
            return await _hardSkillCore.GetHardSkillsAsync();
        }

        // POST api/<HardSkillsController>
        [HttpPost]
        public async Task<HardSkill> Post([FromBody] HardSkillCreateDTO hardSkill)
        {
            return await _hardSkillCore.CreateHardSkillAsync(hardSkill);
        }

        // PUT api/<HardSkillsController>/5
        [HttpPut]
        public async Task<bool> Put(int id, [FromBody] HardSkill hardSkill)
        {
            return await _hardSkillCore.UpdateHardSkillAsync(hardSkill);
        }

        // DELETE api/<HardSkillsController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _hardSkillCore.DeleteHardSkillAsync(id);
        }
    }
}
