using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExemploWEBApi.Entities
{
    public class Pessoa
    {
        public int? idPessoa { get; set; }
        public string nome { get; set; }
        public DateTime? dataNascimento { get; set; }
        public long? cpf { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string pais { get; set; }
        public string cep { get; set; }
        public int? telefoneFixo { get; set; }
        public int? telefoneCelular { get; set; }
        public char? genero { get; set; }

        public Pessoa()
        {

        }
    }
}