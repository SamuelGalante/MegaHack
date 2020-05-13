using MegaHack.Entity;
using MegaHack.Entity.Appointment;
using MegaHack.Entity.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaHack.Context
{
    public class MegaHackContext : DbContext
    {

        public DbSet<User> User { get; set; }
        public DbSet<Diary> Diary { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Diagnosis> Diagnosis { get; set; }
        public DbSet<Professional> Professional { get; set; }
        public DbSet<Patient> Patient { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LOCALHOST;Initial Catalog=MegaHack;User ID=sa; Password=123456;");
        }
    }
}
