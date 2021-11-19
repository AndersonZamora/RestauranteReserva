using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reservas.Models
{
    public class Personal
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Username es obligatorio")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "El Password es obligatorio")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Los Nombres son obligatorios")]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El Rol es obligatorio")]
        [Display(Name = "Rol")]
        public string Rol { get; set; }

    }
}