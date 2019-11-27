using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExemploWEBApi.Entities
{
    public class Coordenacao
    {
        public int? idCoordenacao { get; set; }
        public int? idProfessor { get; set; }
        public int? idCurso { get; set; }
        public int? telefone { get; set; }
        public string email { get; set; }
    }
}