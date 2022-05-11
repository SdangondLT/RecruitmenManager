using System.ComponentModel.DataAnnotations;

namespace RecruitmentManager.Entities.Entities
{
    public class SoftSkill
    {
        [Key]
        public int IdSoftSkill { get; set; }
        public string Description { get; set; }
    }
}