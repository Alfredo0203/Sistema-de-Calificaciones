using Sistema_de_Calificaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sistema_de_Calificaciones.Seguridad
{
    public class Permisos : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var idUsuario = System.Web.HttpContext.Current.Session["IdUsuario"];
            var idString = "0";

            if(idUsuario != null)
            {
                idString = idUsuario.ToString();
            }
            if (!PermisosPorRol.esAdministrador(int.Parse(idString)))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                new
                {
                    controller = "Home",
                    action ="Error"
                }

                ));
            }
        }

    }
        public class PermisosPorRol
        {
            public static bool esAdministrador(int idUsuario)
            {
                if (idUsuario <= 0)
                {
                    return false;
                }

                using (var contexto = new Contexto())
                {
                    var usuario = contexto.Users.FirstOrDefault(x => x.idUsuario == idUsuario);

                    return usuario.roles == Roles.Administrador ? true : false;
                }
            }

        }
    
}