
using Reservas.Interfaces;
using Reservas.Models;
using Reservas.Models.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservas.Service
{
    public class MesaService : IMesa
    {
        private readonly ReservasDbContext _context;


        public MesaService(ReservasDbContext _context)
        {
            this._context = _context;
        }

        public void createMesa(Mesa mesa)
        {
            _context.Mesa.Add(mesa);
            _context.SaveChanges();
        }

        public void deleteMesa(int? id)
        {
            var mesa = _context.Mesa.Find(id);
            _context.Mesa.Remove(mesa);
            _context.SaveChanges();
        }

        public IEnumerable<Mesa> getLista()
        {
            return _context.Mesa;
        }

        public Mesa getMesa(int? id)
        {
            var mesa = _context.Mesa.Where(a => a.Id == id).FirstOrDefault();

            return mesa;
        }

        public IEnumerable<Mesa> getMesaById()
        {
            return _context.Mesa.Where(m => m.Estado == 1).ToList();
        }

        public IEnumerable<Mesa> getMesaByState()
        {
            return _context.Mesa.Where(m => m.Estado == 2).ToList();
        }

        public void updateMesa(Mesa mesa)
        {
            _context.Mesa.Update(mesa);
            _context.SaveChanges();
        }
    }
}
