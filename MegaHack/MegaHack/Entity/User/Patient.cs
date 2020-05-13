using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaHack.Entity.Appointment;

namespace MegaHack.Entity.User
{
    public class Patient : User
    {
        public Patient(string userName, string password, string email) : base(userName, password, email)
        {
        }

    }
}
