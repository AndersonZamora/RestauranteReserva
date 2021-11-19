using Reservas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservas.Interfaces
{
    public interface IMesa
    {
        IEnumerable<Mesa> getLista();
        IEnumerable<Mesa> getMesaById();
        IEnumerable<Mesa> getMesaByState();
        void createMesa(Mesa mesa);
        Mesa getMesa(int? id);
        void updateMesa(Mesa mesa);
        void deleteMesa(int? id);

        
    }
}
