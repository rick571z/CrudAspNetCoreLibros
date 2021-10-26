using CrudAspNetCoreLibros.Data;
using CrudAspNetCoreLibros.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAspNetCoreLibros.Controllers
{
    public class LibrosController : Controller
    {
        //se invoca el ApplicationDbContext, nos permite acceder la bd
        private readonly ApplicationDbContext _context;

        //constructor
        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        /*
         * TRAERA LA LISTA DE LIBROS
         */

        //Http Get Index
        public IActionResult Index()
        {
            IEnumerable<Libro> listaLibros = _context.Libro;
            return View(listaLibros);
        }

        //Http Get Create
        public IActionResult Create()
        {
            return View();
        }

        //Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Libro libro)
        {
            //validar el modelo
            if (ModelState.IsValid)
            {
                _context.Libro.Add(libro);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }


        //Http Get Edit
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            //obtener el libro
            var libro = _context.Libro.Find(id);

            if(libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }


        //Http Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Libro libro)
        {
            //validar el modelo
            if (ModelState.IsValid)
            {
                _context.Libro.Update(libro);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }



        //Http Get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //obtener el libro
            var libro = _context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }


        //Http Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLibro(int? id)
        {

            //obtener el libro por id
            var libro = _context.Libro.Find(id);

            if(libro == null)
            {
                return NotFound();
            }
                _context.Libro.Remove(libro);
                _context.SaveChanges();

            return RedirectToAction("Index");
           
        }


    }
}
