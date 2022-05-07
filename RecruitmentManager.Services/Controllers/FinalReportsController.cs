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
    public class FinalReportsController : ControllerBase
    {
        private readonly FinalReportCore _finalReportCore;

        public FinalReportsController()
        {
            _finalReportCore = new FinalReportCore();
        }

        // GET: api/<FinalReportsController>
        [HttpGet]
        public async Task<IEnumerable<FinalReport>> Get()
        {
            return await _finalReportCore.GetFinalReportsAsync();
        }

        // GET api/<FinalReportsController>/5
        [HttpGet("{id}")]
        public async Task<FinalReport> Get(int id)
        {
            return await _finalReportCore.GetFinalReportAsync(id);
        }

        // POST api/<FinalReportsController>
        [HttpPost]
        public async Task<FinalReport> Post([FromBody] FinalReportCreateDto finalReport)
        {
            return await _finalReportCore.CreateFinalReportAsync(finalReport);
        }

        // PUT api/<FinalReportsController>/5
        [HttpPut]
        public async Task<bool> Put([FromBody] FinalReport finalReport)
        {
            return await _finalReportCore.UpdateFinalReportAsync(finalReport);
        }

        // DELETE api/<FinalReportsController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _finalReportCore.DeleteFinalReportAsync(id);
        }
    }
}
