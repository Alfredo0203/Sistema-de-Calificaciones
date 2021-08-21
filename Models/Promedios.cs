using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_de_Calificaciones.Models
{
    public class Promedios
    {
        [Key]
        public int IdPromedio { get; set; }
        public int IdMateria { get; set; }
        public int IdAlumno { get; set; }

        [Required(ErrorMessage = "La nota 1 es requerida")]
        [Range(0, 10, ErrorMessage = "La nota está fuera del rango")]
        public double Nota1 { get; set; }

        [Required(ErrorMessage = "La nota 2 es requerida")]
        [Range(0, 10, ErrorMessage = "La nota está fuera del rango")]
        public double Nota2 { get; set; }

        [Required(ErrorMessage = "La nota 1 es requerida")]
        [Range(0, 10, ErrorMessage = "La nota está fuera del rango")]
        public double Nota3 { get; set; }

        public double Promedio { get; set; }
        public string Estado { get; set; }

    }
}