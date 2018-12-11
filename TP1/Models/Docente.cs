using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public DateTime? DataDefesa { get; set; }
        public bool Selecionado { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}