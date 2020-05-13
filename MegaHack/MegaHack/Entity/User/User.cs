using CryptSharp;
using MegaHack.Models.FlyWeight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaHack.Entity.User
{
    public class User
    {
        public User(string userName, string password, string email)
        {
            UserName = userName;
            Password = Crypter.MD5.Crypt(password);
            Email = email;
        }

        public int Id { get; set; }
        public Models.FlyWeight.Type Type { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public DateTime DateBirth { get; set; }
        public List<Appointment.Appointment> Appointments { get; set; }

        

    }
}
