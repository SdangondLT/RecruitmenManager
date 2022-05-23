using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentManager.Entities.Entities
{
    public class Interview
    {
        public int IdInterview { get; set; }
        public string Name { get; set; }
        public string MeetingLink { get; set; }
        public DateTime Date { get; set; }
        public int IdInterviwer { get; set; }
        public int IdCandidate { get; set; }
        public int IdRecruiter { get; set; }
        public string Evaluation { get; set; }
        public bool IsActive { get; set; }
    }
}
