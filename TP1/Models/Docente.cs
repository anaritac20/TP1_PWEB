using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP1.Models
{
    public class Docente
    {
        public int ID { get; set; }
        public bool Comissao { get; set; }
        public string Nome { get; set; }
        public IList<Aluno> Aluno { get; set; }
        public IList<Proposta> Propostas { get; set; }

    }
}