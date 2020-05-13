using MegaHack.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaHack.Entity.Appointment
{
    public class Appointment
    {
        
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public Professional Professional { get; set; }
        public DateTime Date { get; set; }
    }
}
