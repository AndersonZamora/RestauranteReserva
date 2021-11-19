using Microsoft.AspNetCore.Mvc;
using Reservas.Interface;
using Reservas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservas.Controllers
{
    public class PlatosController : Controller
    {
        private readonly IPlato platosInterface;
        private readonly ICategoria categoriasInterface;

        public PlatosController(IPlato platosInterface, ICategoria categoriasInterface)
        {
            this.platosInterface = platosInterface;
            this.categoriasInterface = categoriasInterface;
        }

        public IActionResult Index()
        {
            var listaPlatos = platosInterface.getLista();
            return View(listaPlatos);
        }

        public IActionResult Create()
        {
            ViewBag.Categoria = categoriasInterface.getLista();
            return View();
        }


        [HttpPost]
        public IActionResult Create(Plato plato)
        {
            if (ModelState.IsValid)
            {
                platosInterface.createPlato(plato);
                TempData["mensaje"] = "El plato se ha creado correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            var plato = platosInterface.getPlato(id);
            ViewBag.Categoria = categoriasInterface.getLista();
            return View(plato);
        }


        [HttpPost]
        public IActionResult Edit(Plato plato)
        {
            if (ModelState.IsValid)
            {
                platosInterface.updatePlato(plato);
                TempData["mensaje"] = "El plato se ha editado correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }


        public IActionResult Delete(int? id)
        {
            var plato = platosInterface.getPlato(id);
            return View(plato);
        }


        [HttpPost]
        public IActionResult DeletePlato(int? id)
        {
            platosInterface.deletePlato(id);

            TempData["mensaje"] = "El plato se ha eliminado correctamente";
            return RedirectToAction("Index");

        }
    }
}
