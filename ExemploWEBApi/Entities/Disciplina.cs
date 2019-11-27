using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExemploWEBApi.Entities
{
    public class Disciplina
    {
        public int? idDisciplina { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string ementa { get; set; }
        public int? quantidadeAulaSemestral { get; set; }
    }
}