using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentManager.Entities.Entities
{
    public abstract class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Direction { get; set; }
        public int PhoneNumber { get; set; }
        public int SSN { get; set; }
        public byte Age { get; set; }
    }
}
