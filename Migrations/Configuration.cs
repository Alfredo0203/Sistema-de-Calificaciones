namespace Sistema_de_Calificaciones.Migrations
{
    using Sistema_de_Calificaciones.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Sistema_de_Calificaciones.Models.Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Sistema_de_Calificaciones.Models.Contexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var usuario = new Users()
            {
                nombreUsuario = "Administrador",
                Password = "root",
                isActivo = true,
                roles = Roles.Administrador
            };
            context.Users.AddOrUpdate(usuario);
            context.SaveChanges();
        }
    }
}
