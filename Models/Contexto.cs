using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sistema_de_Calificaciones.Models
{

    //Clase para generarbase de datos
    public class Contexto : DbContext
    {
        public DbSet<Alumnos> Alumnos { get; set; }
        public DbSet<Materias> Materias { get; set; }
        public DbSet<Promedios> Promedios { get; set; }
    }
}