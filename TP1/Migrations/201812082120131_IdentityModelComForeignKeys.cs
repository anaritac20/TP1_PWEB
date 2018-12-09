namespace TP1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityModelComForeignKeys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alunos", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Empresas", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Docentes", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Alunos", "UserId");
            CreateIndex("dbo.Empresas", "UserId");
            CreateIndex("dbo.Docentes", "UserId");
            AddForeignKey("dbo.Alunos", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Empresas", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Docentes", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Docentes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Empresas", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Alunos", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Docentes", new[] { "UserId" });
            DropIndex("dbo.Empresas", new[] { "UserId" });
            DropIndex("dbo.Alunos", new[] { "UserId" });
            DropColumn("dbo.Docentes", "UserId");
            DropColumn("dbo.Empresas", "UserId");
            DropColumn("dbo.Alunos", "UserId");
        }
    }
}
