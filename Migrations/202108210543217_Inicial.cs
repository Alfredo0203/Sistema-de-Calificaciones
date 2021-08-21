namespace Sistema_de_Calificaciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alumnos",
                c => new
                    {
                        IdAlumno = c.Int(nullable: false, identity: true),
                        NombreAlumno = c.String(nullable: false),
                        CodigoAlumno = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdAlumno);
            
            CreateTable(
                "dbo.Promedios",
                c => new
                    {
                        IdPromedio = c.Int(nullable: false, identity: true),
                        IdMateria = c.Int(nullable: false),
                        IdAlumno = c.Int(nullable: false),
                        Nota1 = c.Double(nullable: false),
                        Nota2 = c.Double(nullable: false),
                        Nota3 = c.Double(nullable: false),
                        Promedio = c.Double(nullable: false),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.IdPromedio)
                .ForeignKey("dbo.Alumnos", t => t.IdAlumno, cascadeDelete: true)
                .ForeignKey("dbo.Materias", t => t.IdMateria, cascadeDelete: true)
                .Index(t => t.IdMateria)
                .Index(t => t.IdAlumno);
            
            CreateTable(
                "dbo.Materias",
                c => new
                    {
                        IdMateria = c.Int(nullable: false, identity: true),
                        NombreMateria = c.String(nullable: false),
                        CoMateria = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdMateria);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Promedios", "IdMateria", "dbo.Materias");
            DropForeignKey("dbo.Promedios", "IdAlumno", "dbo.Alumnos");
            DropIndex("dbo.Promedios", new[] { "IdAlumno" });
            DropIndex("dbo.Promedios", new[] { "IdMateria" });
            DropTable("dbo.Materias");
            DropTable("dbo.Promedios");
            DropTable("dbo.Alumnos");
        }
    }
}
