using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExemploWEBApi.Entities
{
    public class DiarioEventoAluno
    {
        public int? idDiarioEventoAluno { get; set; }
        public int? idEventosDiario { get; set; }
        public int? idAluno { get; set; }
        public decimal? nota { get; set; }
        public string observacao { get; set; }
    }
}