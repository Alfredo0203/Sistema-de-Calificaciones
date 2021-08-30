using Sistema_de_Calificaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Sistema_de_Calificaciones.Controllers
{
    public class HomeController : Controller
    {

        Contexto contexto = new Contexto();
        public ActionResult Login()
        {
            return View();
        }
        //VALIDAR USUARIO Y CONTRASEÑA
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Users model)
        {
            if (ModelState.IsValid)
            {
                var usuario = contexto.Users.FirstOrDefault(x => x.nombreUsuario.Equals(model.nombreUsuario) &&
                x.Password.Equals(model.Password));
                if(usuario != null)
                {
                    Session["IdUsuario"] = usuario.idUsuario.ToString();
                   return RedirectToAction("MostrarAlumnos", "Alumno");
                }
                else
                {
                    ModelState.AddModelError("Credenciales inválidas", "Usuario contraseña son inorrectos");
                }
            }
            return View();
        }
        // CERRAR SESSIÓN
        public ActionResult Salir()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Login");

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}