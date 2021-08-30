using Rotativa;
using Sistema_de_Calificaciones.Models;
using Sistema_de_Calificaciones.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_de_Calificaciones.Controllers
{
    [Permisos]
    public class ReportesController : Controller
    {
       
        Contexto contexto = new Contexto();
        // GET: Reportes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ImprimirNotasPorAlumno(int idAlumno)
        {
           
            var modelo = contexto.Promedios.Where(x => x.IdAlumno == idAlumno).ToList();
            ViewBag.nombreAlumno = contexto.Alumnos.FirstOrDefault(x => x.IdAlumno == idAlumno).NombreAlumno;

            return new ViewAsPdf("NotasPorAlumno", modelo)
            {
                PageSize = Rotativa.Options.Size.Letter,
                PageMargins = new Rotativa.Options.Margins(20, 10, 20, 10),
                FileName = "NotasAlumno.pdf"
 
            };

        }

        public ActionResult ImprimirNotasPorMateria(int idMateria)
        {
            var modelo = contexto.Promedios.Where(x => x.IdMateria == idMateria).ToList();
            return new ViewAsPdf("NotasPorMateria", modelo)
            {
                PageSize = Rotativa.Options.Size.Letter,
                PageMargins = new Rotativa.Options.Margins(20, 10, 20, 10),
                FileName = "NotasPorMateria.pdf"

            };

            }
    }
}