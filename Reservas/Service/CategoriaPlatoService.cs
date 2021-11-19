using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reservas.Interface;
using Reservas.Models;
using Reservas.Models.Map;

namespace Reservas.Service
{
    public class CategoriaPlatoService : ICategoria
    {
        private readonly ReservasDbContext _context;

        public CategoriaPlatoService(ReservasDbContext _context)
        {
            this._context = _context;
        }

        public void createCategoriaPlato(CategoriaPlato categoriaPlato)
        {
            _context.CategoriaPlato.Add(categoriaPlato);
            _context.SaveChanges();
        }

        public void deleteCategoria(int? id)
        {
            var categoria = _context.CategoriaPlato.Find(id);
            _context.CategoriaPlato.Remove(categoria);
            _context.SaveChanges();
        }

        public CategoriaPlato getCategoria(int? id)
        {
            var categoria = _context.CategoriaPlato.Where(a => a.Id == id).FirstOrDefault();

            return categoria;
        }

        public IEnumerable<CategoriaPlato> getLista()
        {
            return _context.CategoriaPlato;
        }

        public void updateCategoria(CategoriaPlato categoriaPlato)
        {
            _context.CategoriaPlato.Update(categoriaPlato);
            _context.SaveChanges();
        }
    }
}
