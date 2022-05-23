using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentManager.Entities.Entities
{
    public class FinalReport
    {
        public int IdReport { get; set; }
        public int IdCandidate { get; set; }
        public string Seniority { get; set; }
        public string EnglishLevel { get; set; }
        public string Comments { get; set; }

    }
}
