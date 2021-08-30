using Sistema_de_Calificaciones.Models;
using Sistema_de_Calificaciones.Seguridad;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_de_Calificaciones.Controllers
{
    [Permisos]
    public class AlumnoController : Controller
    {

        Contexto contexto = new Contexto();
        // GET: Alumno
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MostrarAlumnos()
        {
            var listaAlumnos = contexto.Alumnos.ToList();

            return View(listaAlumnos);
        }

        public ActionResult CreateOrEditAlumnos(int idAlumno = 0)
        {
            if (idAlumno > 0) 
            {
                var model = contexto.Alumnos.FirstOrDefault(x => x.IdAlumno == idAlumno);
                return View(model);
            }
            else
            {
                var model = new Alumnos();
                return View(model);

            }
        }

        [HttpPost]
        public ActionResult CreateOrEditAlumnos(Alumnos model)
        {
            //Validar que los datos cumplan las validaciones que hicimos en la clase
            if (ModelState.IsValid)
            {
                if (model.IdAlumno > 0)
                {
                    // Editar
                    contexto.Entry(model).State = EntityState.Modified;
         
                }
                else { 

                //Agregar registro
                contexto.Entry(model).State = EntityState.Added;
               

         
                }
                contexto.SaveChanges();
                return RedirectToAction("MostrarAlumnos");
            }
            
                return View(model);
            }

            public ActionResult EliminarAlumnos(int idAlumno)
            {

                var modelo = contexto.Alumnos.FirstOrDefault(x => x.IdAlumno == idAlumno);
                contexto.Entry(modelo).State = EntityState.Deleted;
                contexto.SaveChanges();
                return RedirectToAction("MostrarAlumnos");
            }
        }
    }
