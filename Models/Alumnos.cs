using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sistema_de_Calificaciones.Models
{
    public class Alumnos
    {
        [Key]
        public int IdAlumno { get; set; }
        [Required(ErrorMessage ="El nombre del alumno es requerido")]
        public string NombreAlumno { get; set; }
        [Required(ErrorMessage = "El código del alumno es requerido")]
        public string CodigoAlumno { get; set; }

        [ForeignKey("IdAlumno")]
        public ICollection<Promedios> Promedios { get; set; }



    }
}