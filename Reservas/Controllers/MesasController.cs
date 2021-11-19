using Microsoft.AspNetCore.Mvc;
using Reservas.Models;
using Reservas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Reservas.Controllers
{
    public class MesasController : Controller
    {

        private readonly IMesa mesaInterface;

        public MesasController(IMesa mesaInterface)
        {
            this.mesaInterface = mesaInterface;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var listaMesas = mesaInterface.getLista();
            return View(listaMesas);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Mesa mesa)
        {
            if (ModelState.IsValid)
            {
                mesaInterface.createMesa(mesa);
                TempData["mensaje"] = "La mesa se ha creado correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }


        public IActionResult Edit(int? id)
        {
            var mesa = mesaInterface.getMesa(id);
            return View(mesa);
        }


        [HttpPost]
        public IActionResult Edit(Mesa mesa)
        {
            if (ModelState.IsValid)
            {
                mesaInterface.updateMesa(mesa);

                TempData["mensaje"] = "La mesa se ha editado correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }


        public IActionResult Delete(int? id)
        {
            var mesa = mesaInterface.getMesa(id);
            return View(mesa);
        }


        [HttpPost]
        public IActionResult DeleteMesa(int? id)
        {
            mesaInterface.deleteMesa(id);

            TempData["mensaje"] = "La mesa se ha eliminado correctamente";
            return RedirectToAction("Index");

        }
    }
}
