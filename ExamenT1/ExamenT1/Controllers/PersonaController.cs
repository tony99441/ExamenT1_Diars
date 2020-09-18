using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenT1.BD;
using ExamenT1.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamenT1.Controllers
{
    public class PersonaController : Controller
    {
        T1Context context = new T1Context();

        public IActionResult Index()
        {
            var personas = context.Personas.ToList();
            return View(personas);
        }
        public IActionResult CrearPersonaF() {
            var ciudades = context.Ciudades.ToList();
            ViewBag.Ciudades = ciudades;
            string[] genero = new string[2] {"Maculino", "Femenino" };
            ViewBag.genero = genero;
            return View();
        }
        public IActionResult CrearPersona(Persona persona)
        {
            context.Personas.Add(persona);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult EditarPersonaF(int IdPersona)
        {
            var ciudades = context.Ciudades.ToList();
            ViewBag.Ciudades = ciudades;
            string[] genero = new string[2] { "Maculino", "Femenino" };
            ViewBag.genero = genero;
            
            var PersonaEditar = context.Personas.Where(o => o.Id == IdPersona).FirstOrDefault();

            ViewBag.EditarPersona = PersonaEditar;
            return View();
        }
        public IActionResult EditarPersona(Persona persona)
        {
            context.Personas.Update(persona);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult EliminarPersona(int IdPersona) {
            var personaEliminar = context.Personas.Where(o => o.Id == IdPersona).FirstOrDefault();
      context.Personas.Remove(personaEliminar);
            context.SaveChanges();
            return RedirectToAction("Index");
                }

    }
}
