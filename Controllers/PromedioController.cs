using Sistema_de_Calificaciones.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_de_Calificaciones.Controllers
{
    public class PromedioController : Controller
    {
        Contexto contexto = new Contexto();
        // GET: Promedio
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AgregarNotas(int IdMateria)
        {
            var modelo = new Promedios();

            modelo.IdMateria = IdMateria;

            var listaAlumno = new List<SelectListItem>();

            foreach(var item in contexto.Alumnos.ToList())
                {
                listaAlumno.Add(new SelectListItem { Text = item.NombreAlumno, Value = item.IdAlumno.ToString() });

            }
            ViewBag.Alumno = listaAlumno;


            return View(modelo);
        }

        [HttpPost]
        public ActionResult AgregarNotas(Promedios modelo)
        {
            //VALIDAR QUE ELALUMNONOTENGA REGISTROEN LA MISMA MATERIA
            var existeRegistro = contexto.Promedios.Where(x => x.IdMateria == modelo.IdMateria &&
            x.IdAlumno == modelo.IdAlumno).Any();

            if (ModelState.IsValid && !existeRegistro)
            {
                modelo.Promedio = (modelo.Nota1 + modelo.Nota2 + modelo.Nota3) / 3;
                modelo.Estado = modelo.Promedio >= 6 ? "Aprobado" : "Reprobado";
                contexto.Entry(modelo).State = EntityState.Added;
                contexto.SaveChanges();
                return RedirectToAction("MostrarNotas", new { idMateria = modelo.IdMateria});
            }
            else
            {

                var listaAlumno = new List<SelectListItem>();

                foreach (var item in contexto.Alumnos.ToList())
                {
                    listaAlumno.Add(new SelectListItem { Text = item.NombreAlumno, Value = item.IdAlumno.ToString() });

                }
                ViewBag.Alumno = listaAlumno;
                ViewBag.Error = existeRegistro;
                return View(modelo);
            }
        }

        public ActionResult MostrarNotas(int IdMateria)
        {
            ViewBag.IdMateria = IdMateria;
            var model = contexto.Promedios.Where(x => x.IdMateria == IdMateria).ToList();
            return View(model);
        }

    }
}