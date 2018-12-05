using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TP1.Models
{
    public class TP1Context : DbContext
    {

        public TP1Context() : base("name=DefaultConnection")
        {

        }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Cadeira> Cadeiras { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Proposta> Propostas { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Empresa>()
        //        .HasMany(p => p.Propostas)
        //        .WithMany(p => p.Empresa)
        //        .Map(m => m.ToTable("PescadorConcursos"));
        //}




    }
}