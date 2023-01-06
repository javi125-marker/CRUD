using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.ViewModels
{
    public class ClienteViewModel
    {
        public int id_cli { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(50)]
        public string nombre_cli { get; set; }
        [Required]
        [Display(Name = "Cedula")]
        [StringLength(10)]
        public string cedula_cli { get; set; }
        [Required]
        [Display(Name = "Correo")]
        [StringLength(80)]
        [EmailAddress]
        public string correo_cli { get; set; }
        [Required]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime fechaNacimiento_cli { get; set; }

    }
}