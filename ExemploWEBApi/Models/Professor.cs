using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExemploWEBApi.Models
{
    public class Professor
    {

        private DAO DAO = new DAO();

        public int matricula;

        public Professor()
        {
        }

        public Entities.Professor getEmailProfessor(int idCurso, int idDisciplina)
        {

            try
            {
                //Chama o método da classe DAO que busca no banco
                return DAO.getEmailProfessor(idCurso, idDisciplina);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}