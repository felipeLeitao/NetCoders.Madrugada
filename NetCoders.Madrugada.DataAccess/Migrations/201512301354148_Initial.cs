namespace NetCoders.Madrugada.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ficante",
                c => new
                    {
                        idFicante = c.Int(nullable: false, identity: true),
                        nmFicante = c.String(nullable: false, maxLength: 50),
                        dsObs = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.idFicante);
            
            CreateTable(
                "dbo.Telefone",
                c => new
                    {
                        idTelefone = c.Int(nullable: false, identity: true),
                        idFicante = c.Int(nullable: false),
                        nrTelefone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idTelefone)
                .ForeignKey("dbo.Ficante", t => t.idFicante, cascadeDelete: true)
                .Index(t => t.idFicante);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        idUsuario = c.Int(nullable: false, identity: true),
                        nmUsuario = c.String(nullable: false, maxLength: 50),
                        dsSenha = c.String(nullable: false, maxLength: 200),
                        dsRole = c.String(),
                    })
                .PrimaryKey(t => t.idUsuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telefone", "idFicante", "dbo.Ficante");
            DropIndex("dbo.Telefone", new[] { "idFicante" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Telefone");
            DropTable("dbo.Ficante");
        }
    }
}
