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
    public class VacanciesController : ControllerBase
    {
        private readonly VacancyCore _vacancyCore;

        public VacanciesController()
        {
            _vacancyCore = new VacancyCore();
        }

        // GET: api/<VacanciesController>
        [HttpGet]
        public async Task<IEnumerable<Vacancy>> Get()
        {
            return await _vacancyCore.GetVacanciesAsync();
        }

        // POST api/<VacanciesController>
        [HttpPost]
        public async Task<Vacancy> Post([FromBody] VacancyCreateDto vacancy)
        {
            return await _vacancyCore.CreateVacancyAsync(vacancy);
        }

        // PUT api/<VacanciesController>/5
        [HttpPut]
        public async Task<bool> Put([FromBody] Vacancy vacancy)
        {
            return await _vacancyCore.UpdateVacancyAsync(vacancy);
        }

        // DELETE api/<VacanciesController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _vacancyCore.DeleteVacancyAsync(id);
        }
    }
}
