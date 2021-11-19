using Microsoft.EntityFrameworkCore;
using Reservas.Interface;
using Reservas.Models;
using Reservas.Models.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservas.Service
{
    public class PlatoService : IPlato
    {
        private readonly ReservasDbContext _context;

        public PlatoService(ReservasDbContext _context)
        {
            this._context = _context;
        }

        public void createPlato(Plato plato)
        {
            _context.Plato.Add(plato);
            _context.SaveChanges();
        }

        public void deletePlato(int? id)
        {
            var plato = _context.Plato.Find(id);
            _context.Plato.Remove(plato);
            _context.SaveChanges();
        }

        public IEnumerable<Plato> getLista()
        {
            return _context.Plato.Include(p => p.CategoriaPlato).ToList();
        }

        public Plato getPlato(int? id)
        {
            var plato = _context.Plato.Where(a => a.Id == id).Include(m => m.CategoriaPlato).FirstOrDefault(); ;

            return plato;
        }

        public void updatePlato(Plato plato)
        {
            _context.Plato.Update(plato);
            _context.SaveChanges();
        }
    }
}
