using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExemploWEBApi.Entities
{
    public class Professor
    {
        public int? idProfessor { get; set; }
        public int? matricula { get; set; }
        public string email { get; set; }
        public DateTime dataAdmissao { get; set; }
        public DateTime dataDemissao { get; set; }
    }
}