namespace Sistema_de_Calificaciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Materias", "CodigoMateria", c => c.String(nullable: false));
            DropColumn("dbo.Materias", "CoMateria");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Materias", "CoMateria", c => c.String(nullable: false));
            DropColumn("dbo.Materias", "CodigoMateria");
        }
    }
}
