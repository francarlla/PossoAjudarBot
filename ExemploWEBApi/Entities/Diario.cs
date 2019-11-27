using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExemploWEBApi.Entities
{
    public class Diario
    {
        public int? idDiario { get; set; }
        public int? idCurso { get; set; }
        public int? idDisciplina { get; set; }
        public int? semestre { get; set; }
        public int? ano { get; set; }
        public DateTime dataFechamento { get; set; }
    }
}