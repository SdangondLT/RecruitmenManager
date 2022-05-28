
namespace RecruitmentManager.Entities.DTOs
{
    public class VacancyCreateDto
    {
        public int IdRecruiter { get; set; }
        public int IdClient { get; set; }
        public string Seniority { get; set; }
        public string Skills { get; set; }
        public int AvailableVacancies { get; set; }
        public string Description { get; set; }
        public string IsOpen { get; set; }
        public string Candidates { get; set; }
        public string WinnerCandidates { get; set; }
    }
}
