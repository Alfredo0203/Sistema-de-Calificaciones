﻿using System.Web;
using System.Web.Mvc;

namespace Sistema_de_Calificaciones
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
