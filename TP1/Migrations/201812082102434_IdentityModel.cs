namespace TP1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Propostas", "Orientador_ID", "dbo.Docentes");
            DropIndex("dbo.Propostas", new[] { "Orientador_ID" });
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.DocentePropostas",
                c => new
                    {
                        Docente_ID = c.Int(nullable: false),
                        Proposta_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Docente_ID, t.Proposta_ID })
                .ForeignKey("dbo.Docentes", t => t.Docente_ID, cascadeDelete: true)
                .ForeignKey("dbo.Propostas", t => t.Proposta_ID, cascadeDelete: true)
                .Index(t => t.Docente_ID)
                .Index(t => t.Proposta_ID);
            
            AddColumn("dbo.Alunos", "Avaliacao", c => c.Int(nullable: false));
            AddColumn("dbo.Propostas", "Aceite", c => c.Boolean(nullable: false));
            AddColumn("dbo.Propostas", "JustiAceite", c => c.String());
            AddColumn("dbo.Propostas", "Avaliacao", c => c.Int(nullable: false));
            AddColumn("dbo.Docentes", "DataDefesa", c => c.DateTime(nullable: false));
            DropColumn("dbo.Propostas", "Orientador_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Propostas", "Orientador_ID", c => c.Int());
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.DocentePropostas", "Proposta_ID", "dbo.Propostas");
            DropForeignKey("dbo.DocentePropostas", "Docente_ID", "dbo.Docentes");
            DropIndex("dbo.DocentePropostas", new[] { "Proposta_ID" });
            DropIndex("dbo.DocentePropostas", new[] { "Docente_ID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropColumn("dbo.Docentes", "DataDefesa");
            DropColumn("dbo.Propostas", "Avaliacao");
            DropColumn("dbo.Propostas", "JustiAceite");
            DropColumn("dbo.Propostas", "Aceite");
            DropColumn("dbo.Alunos", "Avaliacao");
            DropTable("dbo.DocentePropostas");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            CreateIndex("dbo.Propostas", "Orientador_ID");
            AddForeignKey("dbo.Propostas", "Orientador_ID", "dbo.Docentes", "ID");
        }
    }
}
