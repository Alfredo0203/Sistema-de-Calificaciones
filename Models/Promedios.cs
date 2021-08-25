using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sistema_de_Calificaciones.Models
{
    
    public class Promedios
    {
        Contexto contexto = new Contexto();
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

        [NotMapped]
        public string NombreAlumno
        {
            get 
            {
                return contexto.Alumnos.FirstOrDefault(x => x.IdAlumno == IdAlumno).NombreAlumno;
                    }
        }

        [NotMapped]
        public string NombreMateria
        {
            get
            {
                return contexto.Materias.FirstOrDefault(x => x.IdMateria == IdMateria).NombreMateria;
            }
        }

    }
}