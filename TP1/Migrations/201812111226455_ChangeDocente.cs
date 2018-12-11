namespace TP1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDocente : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Docentes", "DataDefesa", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Docentes", "DataDefesa", c => c.DateTime(nullable: false));
        }
    }
}
