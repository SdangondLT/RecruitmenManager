using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentManager.Entities.DTOs
{
    public class CandidateCreateDto
    {
        public string Name { get; set; }
        public string CV { get; set; }
        public string CandidateType { get; set; }
        public string HardSkills { get; set; }
        public string Seniority { get; set; }
        public string SoftSkills { get; set; }
        public int YearsOfExperience { get; set; }
    }
}
