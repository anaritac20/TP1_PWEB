using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP1.Models
{
    public class Cadeira
    {
        public int ID { get; set; }
        public int ETCS { get; set; }
        public string Nome { get; }
        public bool Concluida { get; set; }

    }
}