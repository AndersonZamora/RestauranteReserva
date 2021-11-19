using Reservas.Interfaces;
using Reservas.Models;
using Reservas.Models.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservas.Service
{
    public class PersonaService : IPersonal
    {
        private readonly ReservasDbContext _context;

        public PersonaService(ReservasDbContext _context)
        {
            this._context = _context;
        }

        public void createPersonal(Personal personal)
        {
            _context.Personal.Add(personal);
            _context.SaveChanges();
        }

        public void deletePersona(int? id)
        {
            var personal = _context.Personal.Find(id);
            _context.Personal.Remove(personal);
            _context.SaveChanges();
        }
        public IEnumerable<Personal> getLista()
        {
            return _context.Personal;
        }

        public Personal getPersonal(int? id)
        {
            var personal = _context.Personal.Where(a => a.Id == id).FirstOrDefault();
            return personal;
        }

        public void updatePersonal(Personal personal)
        {
            _context.Personal.Update(personal);
            _context.SaveChanges();
        }
    }
}