using ExemploWEBApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExemploWEBApi.Models
{
    public class Curso
    {
        private DAO DAO = new DAO();

        public int idCurso;

        public Curso()
        {
        }

        public Coordenacao getContatoCoordenacao(int idCurso)
        {

            try
            {
                //Chama o método da classe DAO que busca no banco
                return DAO.getContatoCoordenacao(idCurso);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}