using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TP1.Models
{
    [Table("Alunos")]
    public class Aluno
    {
        public enum Tipo
        {
            SI = 0,
            DA = 1,
            RAS = 2
        };

        public int ID { get; set; }
        public string Nome { get; set; }
        public int nAluno { get; set; }
        public IList<Proposta> Candidatura { get; set; }
        [DataType(DataType.MultilineText)]
        public string Curriculo { get; set; }
        public Tipo Ramo { get; set; }
        public int Avaliacao { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public Aluno()
        {
            Candidatura = new List<Proposta>();
        }
    }
}