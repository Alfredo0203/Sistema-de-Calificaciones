namespace Sistema_de_Calificaciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alumnos", "IdMateria", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Alumnos", "IdMateria");
        }
    }
}
