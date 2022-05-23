using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentManager.Entities.DTOs
{
    public class AssessmentCreateDto
    {
        public string NameAssessment { get; set; }
        public int IdCandidate { get; set; }
        public int IdQuestionnaire { get; set; }
    }
}
