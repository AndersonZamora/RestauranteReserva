using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reservas.Interfaces;
using Reservas.Models;

namespace Reservas.Controllers
{
    public class UsuariosController : Controller
    {

        protected readonly IPersonal IPersonal;

        public UsuariosController(IPersonal IPersonal)
        {
            this.IPersonal = IPersonal;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var listaPersonal = IPersonal.getLista();
            return View(listaPersonal);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Personal personal)
        {
            if (ModelState.IsValid)
            {
                IPersonal.createPersonal(personal);
                TempData["mensaje"] = "El usuario se ha creado correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Edit(int? id)
        {
            var peronal = IPersonal.getPersonal(id);
            return View(peronal);
        }

        [HttpPost]
        public IActionResult Edit(Personal personal)
        {
            if (ModelState.IsValid)
            {
                IPersonal.updatePersonal(personal);

                TempData["mensaje"] = "El usuario se ha editado correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }


        public IActionResult Delete(int? id)
        {
            var personal = IPersonal.getPersonal(id);
            return View(personal);
        }

        [HttpPost]
        public IActionResult DeleteMesa(int? id)
        {
            IPersonal.deletePersona(id);
            TempData["mensaje"] = "El usuario se ha eliminado correctamente";
            return RedirectToAction("Index");

        }
    }
}