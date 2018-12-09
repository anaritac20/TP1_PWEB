using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TP1.Models
{
    public class Proposta
    {

        public enum Ramos
        {
            SI = 0,
            DA = 1,
            RAS = 2
        };
        public int ID { get; set; }

        public Empresa Empresas { get; set; }
        public Aluno Student { get; set; }
        public string Titulo { get; set; }
        public Ramos Ramo { get; set; }
        public IList<Docente> Orientadores { get; set; }
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }
        public string Local { get; set; }
        public bool Livre { get; set; }
        public bool Aceite { get; set; }
        public string JustiAceite { get; set; }
        public int Avaliacao { get; set; }

    }
}