using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExemploWEBApi.Entities
{
    public class ProfessorCursoDisciplina
    {
        public int? idProfessorCursoDisciplina { get; set; }
        public int? idProfessor { get; set; }
        public int? idCurso { get; set; }
        public int? idDisciplina { get; set; }
    }
}