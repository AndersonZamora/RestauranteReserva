using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reservas.Models
{
    public class CategoriaPlato
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de categoría es obligatorio")]
        [Display(Name = "NombreCategoria")]
        public string NombreCategoria { get; set; }

    }
}
