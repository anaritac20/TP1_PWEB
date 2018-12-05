namespace TP1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IniticalModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alunos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        nAluno = c.Int(nullable: false),
                        Ramo = c.Int(nullable: false),
                        Docente_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Docentes", t => t.Docente_ID)
                .Index(t => t.Docente_ID);
            
            CreateTable(
                "dbo.Cadeiras",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ETCS = c.Int(nullable: false),
                        Nome = c.String(),
                        Concluida = c.Boolean(nullable: false),
                        Aluno_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Alunos", t => t.Aluno_ID)
                .Index(t => t.Aluno_ID);
            
            CreateTable(
                "dbo.Propostas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Ramo = c.Int(nullable: false),
                        Descricao = c.String(),
                        Local = c.String(),
                        Livre = c.Boolean(nullable: false),
                        Empresas_ID = c.Int(),
                        Orientador_ID = c.Int(),
                        Student_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Empresas", t => t.Empresas_ID)
                .ForeignKey("dbo.Docentes", t => t.Orientador_ID)
                .ForeignKey("dbo.Alunos", t => t.Student_ID)
                .Index(t => t.Empresas_ID)
                .Index(t => t.Orientador_ID)
                .Index(t => t.Student_ID);
            
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Telefone = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Docentes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Comissao = c.Boolean(nullable: false),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Propostas", "Student_ID", "dbo.Alunos");
            DropForeignKey("dbo.Propostas", "Orientador_ID", "dbo.Docentes");
            DropForeignKey("dbo.Alunos", "Docente_ID", "dbo.Docentes");
            DropForeignKey("dbo.Propostas", "Empresas_ID", "dbo.Empresas");
            DropForeignKey("dbo.Cadeiras", "Aluno_ID", "dbo.Alunos");
            DropIndex("dbo.Propostas", new[] { "Student_ID" });
            DropIndex("dbo.Propostas", new[] { "Orientador_ID" });
            DropIndex("dbo.Propostas", new[] { "Empresas_ID" });
            DropIndex("dbo.Cadeiras", new[] { "Aluno_ID" });
            DropIndex("dbo.Alunos", new[] { "Docente_ID" });
            DropTable("dbo.Docentes");
            DropTable("dbo.Empresas");
            DropTable("dbo.Propostas");
            DropTable("dbo.Cadeiras");
            DropTable("dbo.Alunos");
        }
    }
}
