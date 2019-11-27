using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExemploWEBApi.Entities
{
    public class CursoDisciplina
    {
        public int? idCurso { get; set; }
        public int? idDisciplina { get; set; }
        public int? periodoOfertado { get; set; }
        public int? quantidadeVagas { get; set; }
    }
}