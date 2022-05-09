
using System.ComponentModel.DataAnnotations;

namespace RecruitmentManager.Entities.Entities
{
    public class Client
    {
        [Key]
        public int IdClient { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
