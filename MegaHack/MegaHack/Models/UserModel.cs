using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaHack.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName  { get; set; }
        public string Password { get; set; }
        public int Type { get; set; }
        public int Gender { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateBirth { get; set; }
        public string Phone { get; set; }
        public string CRP { get; set; }
        public int Specialty { get; set; }
        public DateTime CareerTime { get; set; }
    }
}
