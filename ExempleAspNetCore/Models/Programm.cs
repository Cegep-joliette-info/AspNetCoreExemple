using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExempleAspNetCore.Models
{
    // 2 m pour enlever le conflit du nom réservé Program
    public class Programm
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Course> Courses { get; set; }
    }
}
