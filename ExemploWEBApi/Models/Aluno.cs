using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExemploWEBApi.Models
{
    public class Aluno
    {
        private DAO DAO = new DAO();

        public int matricula;

        public Aluno()
        {
        }

        public Entities.Aluno getDadosCadastrais(int matricula)
        {

            try
            {
                //Chama o método da classe DAO que busca no banco
                return DAO.getDadosCadastrais(matricula);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Entities.AlunoDisciplina> getDisciplinas(int matricula)
        {

            try
            {
                //Chama o método da classe DAO que busca no banco
                return DAO.getDisciplinas(matricula);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}