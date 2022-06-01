using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentManager.Entities.Entities
{
    public class Recruiter : Person
    {
        public int IdRecruiter { get; set; }
        public string Seniority { get; set; }
        public string TypeOfTechnology { get; set; }
        public string SocialSecurityNumber { get; set; }
    }
}
