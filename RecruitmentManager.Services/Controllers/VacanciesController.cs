using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecruitmentManager.Core.Core.V1;
using RecruitmentManager.DataAccess.Context;
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

        public VacanciesController(ILogger<Vacancy> logger, IMapper mapper, SqlServerContext context)
        {
            _vacancyCore = new VacancyCore(logger, mapper, context);
        }

        // GET: api/<VacanciesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vacancy>>> Get()
        {
            var response = await _vacancyCore.GetVacanciesAsync();
            return StatusCode((int)response.StatusHttp, response);
        }

        // POST api/<VacanciesController>
        [HttpPost]
        public async Task<ActionResult<Vacancy>> Post([FromBody] VacancyCreateDto vacancy)
        {
            var response = await _vacancyCore.CreateVacancyAsync(vacancy);
            return StatusCode((int)response.StatusHttp, response);
        }

        // PUT api/<VacanciesController>/5
        [HttpPut]
        public async Task<ActionResult<bool>> Put([FromBody] Vacancy vacancy)
        {
            var response = await _vacancyCore.UpdateVacancyAsync(vacancy);
            return StatusCode((int)response.StatusHttp, response);
        }

        // DELETE api/<VacanciesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var response = await _vacancyCore.DeleteVacancyAsync(id);
            return StatusCode((int)response.StatusHttp, response);
        }
    }
}
