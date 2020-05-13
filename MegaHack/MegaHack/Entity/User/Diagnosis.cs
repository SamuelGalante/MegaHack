using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaHack.Entity.User
{
    public class Diagnosis
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Professional Professional { get; set; }
        public Patient Patient { get; set; }
    }
}
