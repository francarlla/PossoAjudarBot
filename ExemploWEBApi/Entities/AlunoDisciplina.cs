using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExemploWEBApi.Entities
{
    public class AlunoDisciplina
    {
        public int? idAlunoDisciplina { get; set; }
        public int? idAluno { get; set; }
        public int? idDisciplina { get; set; }
        public string nomeDisciplina { get; set; }
        public int? quantidadeFalta { get; set; }
        public char? idStatusDisciplina { get; set; }
        public int? semestre { get; set; }
        public int? ano { get; set; }
    }
}