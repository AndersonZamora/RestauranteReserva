using Reservas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservas.Interface
{
    public interface IPlato
    {
        IEnumerable<Plato> getLista();
        void createPlato(Plato plato);
        Plato getPlato(int? id);
        void updatePlato(Plato plato);
        void deletePlato(int? id);
    }
}
