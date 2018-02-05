using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExempleAspNetCore.ViewModels
{
    public class ProgrammIndex
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int ClassCount { get; set; }
    }
    public class ProgrammCreate
    {
        [Required(ErrorMessage = "Le code de programme est obligatoire")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Le code de programme doit être composé de 3 lettres")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Le nom du programme est obligatoire")]
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ProgrammEdit
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Le code de programme est obligatoire")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Le code de programme doit être composé de 3 lettres")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Le nom du programme est obligatoire")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
