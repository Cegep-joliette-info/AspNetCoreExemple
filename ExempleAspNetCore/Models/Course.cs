using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExempleAspNetCore.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Programm Program { get; set; }
    }
}
