﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExemploWEBApi.Entities
{
    public class Curso
    {
        public int? idCurso { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public int? quantidadePeriodos { get; set; }
    }
}