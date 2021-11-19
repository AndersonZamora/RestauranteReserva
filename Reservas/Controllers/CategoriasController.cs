using Microsoft.AspNetCore.Mvc;
using Reservas.Interface;
using Reservas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservas.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoria categoriaInterface;

        public CategoriasController(ICategoria categoriaInterface)
        {
            this.categoriaInterface = categoriaInterface;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var listaCategorias = categoriaInterface.getLista();
            return View(listaCategorias);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoriaPlato categoriaPlato)
        {
            if (ModelState.IsValid)
            {
                categoriaInterface.createCategoriaPlato(categoriaPlato);
                TempData["mensaje"] = "La categoria se ha creado correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            var categoria = categoriaInterface.getCategoria(id);
            return View(categoria);
        }


        [HttpPost]
        public IActionResult Edit(CategoriaPlato categoriaPlato)
        {
            if (ModelState.IsValid)
            {
                categoriaInterface.updateCategoria(categoriaPlato);

                TempData["mensaje"] = "La categoria se ha editado correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            var categoria = categoriaInterface.getCategoria(id);
            return View(categoria);
        }


        [HttpPost]
        public IActionResult DeleteCategoria(int? id)
        {
            categoriaInterface.deleteCategoria(id);

            TempData["mensaje"] = "La categoría se ha eliminado correctamente";
            return RedirectToAction("Index");
        }

    }
}
