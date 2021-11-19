using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reservas.Models
{
    public class Plato
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del plato es obligatorio")]
        [Display(Name = "NombrePlato")]
        public string NombrePlato { get; set; }

        [Required(ErrorMessage = "La descripción del plato es obligatorio")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio del plato es obligatorio")]
        [Display(Name = "Precio")]
        public Double Precio { get; set; }

        public CategoriaPlato CategoriaPlato { get; set; }

        [Required(ErrorMessage = "La categoría del plato es obligatorio")]
        [Display(Name = "CategoriaId")]
        public int CategoriaId { get; set; }


    }
}
