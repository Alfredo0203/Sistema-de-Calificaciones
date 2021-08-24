using Sistema_de_Calificaciones.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_de_Calificaciones.Controllers
{
    public class MateriaController : Controller
    {
        Contexto contexto = new Contexto();
        // GET: Materia
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MostrarMaterias()
        {
            var listaMaterias = contexto.Materias.ToList();
            return View(listaMaterias);
        }

        public ActionResult CreateOrEditMaterias(int idMateria = 0)
        {
            if(idMateria > 0)
            {
                var model = contexto.Materias.FirstOrDefault(x => x.IdMateria == idMateria);
                return View(model);
            }
            else
            {
                var model = new Materias();
                return View(model);

            }
           
        }
        [HttpPost]
       public ActionResult CreateOrEditMaterias(Materias model)
        {
            if(ModelState.IsValid)
            {
                if(model.IdMateria > 0)
                {

                    contexto.Entry(model).State = EntityState.Modified;
  
                } else
                {
                    contexto.Entry(model).State = EntityState.Added;
                }

                contexto.SaveChanges();
                return RedirectToAction("MostrarMaterias");
            }
           
                return View();
            }
        
        public ActionResult EliminarMateria(int idMateria)
        {
            var model = contexto.Materias.FirstOrDefault(x => x.IdMateria == idMateria);
            contexto.Entry(model).State = EntityState.Deleted;
            contexto.SaveChanges();
            return RedirectToAction("MostrarMaterias");
        }

    }
}