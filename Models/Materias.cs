using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sistema_de_Calificaciones.Models
{
    public class Materias
    {
        [Key]
        public int IdMateria { get; set; }

        [Required(ErrorMessage = "El nombre de la materia es requerido")]
        public string NombreMateria { get; set; }

        [Required(ErrorMessage = "El Código de la materia es requerido")]
        public string CodigoMateria { get; set; }

        [ForeignKey("IdMateria")]
        public ICollection<Promedios> Promedios { get; set; }
    }
}