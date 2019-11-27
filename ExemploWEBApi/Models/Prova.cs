using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using ExemploWEBApi.Entities;

namespace ExemploWEBApi.Models
{
    public class Prova
    {

        private DAO DAO = new DAO();

        public int matricula;

        public Prova()
        {
        }

        public List<EventosDiario> getDataProximaProva(int matricula)
        {

            try
            {
                //Chama o método da classe DAO que busca no banco
                return DAO.getDataProximaProva(matricula);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<EventosDiario> getProvas(int matricula)
        {

            try
            {
                //Chama o método da classe DAO que busca no banco
                return DAO.getProvas(matricula);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}