namespace TP1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SemCadeira : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cadeiras", "Aluno_ID", "dbo.Alunos");
            DropIndex("dbo.Cadeiras", new[] { "Aluno_ID" });
            AddColumn("dbo.Alunos", "Curriculo", c => c.String());
            DropTable("dbo.Cadeiras");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.ID);
            
            DropColumn("dbo.Alunos", "Curriculo");
            CreateIndex("dbo.Cadeiras", "Aluno_ID");
            AddForeignKey("dbo.Cadeiras", "Aluno_ID", "dbo.Alunos", "ID");
        }
    }
}
