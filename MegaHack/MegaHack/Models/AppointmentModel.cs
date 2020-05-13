using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaHack.Models
{
    public class AppointmentModel
    {
        public int Id { get; set; }
        public int IdPatient { get; set; }
        public int IdProfessional { get; set; }
        public DateTime Date { get; set; }
    }
}
