namespace TP1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Docentes", "Selecionado", c => c.Boolean(nullable: false));
            DropColumn("dbo.Empresas", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Empresas", "Email", c => c.String());
            DropColumn("dbo.Docentes", "Selecionado");
        }
    }
}
