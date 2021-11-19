using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reservas.Models
{
    public class Mesa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El número de mesa es obligatorio")]
        [Display(Name ="NumeroMesa")]
        public string NumeroMesa { get; set; }

        [Required(ErrorMessage = "Número de personas para la mesa es obligatorio")]
        [Display(Name = "NumeroPersonas")]
        public int NumeroPersonas { get; set; }

        [Required(ErrorMessage = "La descripción de la mesa es obligatorio")]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El estado de la mesa es obligatorio")]
        [Display(Name = "Estado")]
        public int Estado { get; set; }
    }
}
