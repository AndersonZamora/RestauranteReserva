using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reservas.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del cliente es obligatorio")]
        [Display(Name = "NombreCliente")]
        public string NombreCliente { get; set; }
        [Required(ErrorMessage = "El número de celular es obligatorio")]
        [Display(Name = "Celular")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "La Fecha de Reserva es obligatoria")]
        [Display(Name = "FechaReserva")]
        public DateTime FechaReserva { get; set; }
        public Mesa Mesa { get; set; }
        [Required(ErrorMessage = "El número de mesa es obligatorio")]
        [Display(Name = "MesaId")]
        public int MesaId { get; set; }
    }
}
