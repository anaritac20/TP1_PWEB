using TP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP1
{
    public sealed class Context
    {

        private static Context db = null;
        static readonly object _lock = new object();
        public List<Proposta> LPropostas { get; set; }
        public List<Docente> LDocentes { get; set; }
        public List<Empresa> LEmpresas { get; set; }
        private Context()
        {

            LPropostas = new List<Proposta>()
            {
                new Proposta() { Descricao="Descriçao 1", Local="Coimbra", Ramo= Proposta.Ramos.DA, Titulo="Titulo 1" },
                new Proposta() {Descricao="Descriçao 2", Local="Açores", Ramo= Proposta.Ramos.DA, Titulo="Titulo 2" },
                new Proposta() { Descricao="Descriçao 3", Local="Lisboa", Ramo= Proposta.Ramos.SI, Titulo="Titulo 3" },
                  new Proposta() { Descricao="Descriçao 4", Local="Porto", Ramo= Proposta.Ramos.RAS, Titulo="Titulo 4" }
             };

            LDocentes = new List<Docente>()
            {
            new Docente() { Comissao=true, Nome="Amâncio"  },
            new Docente() { Comissao=true, Nome="Chuva"   },
            new Docente() { Comissao=false, Nome="Marinho"   },
            };

            LEmpresas = new List<Empresa>()
            {
            new Empresa() { Nome="Critial", Telefone=123456789, Email="critical@isec.pt" },
            new Empresa() {  Nome="WIT", Telefone=261548365, Email="wit@isec.pt"  },
            new Empresa() {  Nome="ISEC", Telefone=164648637, Email="ISEC@isec.pt"  },
            };

        }

        public static Context Db
        {
            get
            {
                lock (_lock)
                {
                    if (db == null)
                    {
                        db = new Context();
                    }
                    return db;
                }
            }
        }
    }



}