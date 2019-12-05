using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExemploWEBApi.Entities
{
    public class EventosDiario
    {
        public int? idEventosDiario { get; set; }
        public int? idTipoEvento { get; set; }
        public int? idDiario { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public decimal? pontuacao { get; set; }
        public string dataInicio { get; set; }
        public string dataFim { get; set; }

        public EventosDiario()
        {

        }

    }
}