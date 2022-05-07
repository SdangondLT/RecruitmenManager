using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentManager.Entities.DTOs
{
    public class FinalReportCreateDto
    {
        public int IdCandidate { get; set; }
        public string Seniority { get; set; }
        public string EnglishLevel { get; set; }
        public string Comments { get; set; }
    }
}
