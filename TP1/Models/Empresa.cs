using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TP1.Models
{
    public class Empresa
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int Telefone { get; set; }
        public IList<Proposta> Propostas { get; set; }     //Lista

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Empresa()
        {
            Propostas = new List<Proposta>();
        }
    }
}