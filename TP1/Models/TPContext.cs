using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TP.Models
{

    public class TPContext : DbContext
    {
        public TPContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Cadeira> Cadeiras { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Proposta> Propostas { get; set; }


    }
}