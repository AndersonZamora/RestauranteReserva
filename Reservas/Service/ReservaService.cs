
using Microsoft.EntityFrameworkCore;
using Reservas.Interfaces;
using Reservas.Models;
using Reservas.Models.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservas.Service
{
    public class ReservaService : IReserva
    {
        private readonly ReservasDbContext _context;

        public ReservaService(ReservasDbContext _context)
        {
            this._context = _context;
        }

        public void createReserva(Reserva reserva)
        {
            _context.Reserva.Add(reserva);
            _context.SaveChanges();
            var id = reserva.MesaId;

            var ad = _context.Reserva.Where(a => a.FechaReserva == reserva.FechaReserva).ToList();

            Mesa mesae = _context.Mesa.Where(a => a.Id == id).FirstOrDefault();
            mesae.Estado = 3;
            _context.Update(mesae);
            _context.SaveChanges();
        }

        public void deleteReserva(int? id)
        {
            var reserva = _context.Reserva.Find(id);

            _context.Reserva.Remove(reserva);
            _context.SaveChanges();


            var mesa = _context.Mesa.Where(a => a.Id == reserva.MesaId).FirstOrDefault();
            mesa.Estado = 2;

            _context.Update(mesa);
            _context.SaveChanges();
        }

        public IEnumerable<Reserva> getLista()
        {
            return _context.Reserva.Include(m => m.Mesa).ToList();
        }

        public IEnumerable<Reserva> getLista(string criterio)
        {
            var query = from p in _context.Reserva.Include(a => a.Mesa)
                        select p;

            if (!string.IsNullOrEmpty(criterio))
            {
                query = from p in query
                        where p.NombreCliente.ToUpper().Contains(criterio.ToUpper())
                        select p;
            }

            return query;

        }

        public Reserva getReserva(int? id)
        {
            return _context.Reserva.Where(a => a.Id == id).Include(m => m.Mesa).FirstOrDefault();
        }

        public void updateReserva(Reserva reserva, int id)
        {
            var a = _context.Reserva.Where(i => i.Id == reserva.Id).FirstOrDefault();
            a.MesaId = reserva.MesaId;
            a.NombreCliente = reserva.NombreCliente;
            a.FechaReserva = reserva.FechaReserva;
            a.Celular = reserva.Celular;

            _context.Reserva.Update(a);
            _context.SaveChanges();

            var tmp = _context.Mesa.Where(a => a.Id == id).FirstOrDefault();
            tmp.Estado = 2;

            _context.Update(tmp);
            _context.SaveChanges();

            var mesa = _context.Mesa.Where(a => a.Id == reserva.MesaId).FirstOrDefault();
            mesa.Estado = 3;

            _context.Update(mesa);
            _context.SaveChanges();
        }
    }
}
