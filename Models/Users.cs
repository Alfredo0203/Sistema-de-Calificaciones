using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_de_Calificaciones.Models
{
    public class Users
        {
     [Key]
    public int idUsuario { get; set; }
    [Required(ErrorMessage = "El nombre es necesario")]
    public string nombreUsuario { get; set; }
    [Required(ErrorMessage = "La contraseña es obligatoria")]
    public string Password { get; set; }
    public bool isActivo { get; set; }
    public Roles roles { get; set; }
}

public enum Roles
{
    [Description("Administrador")]
    Administrador = 1,
    [Description("Usuarios")]
    Usuario = 2,
    [Description("Alumnos")]
    Alumno = 3
}
}