using MegaHack.Models.FlyWeight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaHack.Entity.User
{
    public class Professional : User
    {
        public Professional(string userName, string password, string email) : base(userName, password, email)
        {
            Patients = new List<Patient>();
        }
        public string CRP { get; set; }
        public Specialty Specialty { get; set; }
        public DateTime CareerTime { get; set; }
        public List<Patient> Patients { get; set; }

    }
}
