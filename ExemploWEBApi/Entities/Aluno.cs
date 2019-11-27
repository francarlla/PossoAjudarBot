using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExemploWEBApi.Entities
{
    public class Aluno
    {

        public Aluno()
        {

        }

        public int? matricula { get; set; }
        public int? idCurso { get; set; }
        public string email { get; set; }
        public DateTime? dataMatricula { get; set; }
        public DateTime? dataConclusaoCurso { get; set; }
    }
}