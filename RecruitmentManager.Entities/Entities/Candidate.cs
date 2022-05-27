using System.ComponentModel.DataAnnotations;

namespace RecruitmentManager.Entities.Entities
{
    public class Candidate:Person
    {
        [Key]
        public int IdCandidate { get; set; }
        public bool IsEvaluated { get; set; }
        public string CV { get; set; }
        public string CandidateType { get; set; }
        public string Seniority { get; set; }
        public int YearsOfExperience { get; set; }
        public bool ResponseRecruiter { get; set; }
        public bool IsHired { get; set; }
    }
}
