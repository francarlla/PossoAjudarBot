using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ExemploWEBApi.Entities;

namespace ExemploWEBApi.Models
{
    public class DAO
    {
        private SqlConnection conexao;        
        private DataTable dataTable;
        private SqlCommand executaComando;
        private SqlDataAdapter retornoQuery;

        private string query;
        private string dadosConexao;
        
        public DAO()
        {
            //Conecta no banco de dados
            this.dadosConexao = "Server=tcp:mockpucminasapidbserver.database.windows.net,1433;Initial Catalog=mockPucMinasAPI_TCC_db;Persist Security Info=False;User ID=tcc_admin;Password=Lanberjek007$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            this.conexao = new SqlConnection(dadosConexao);

            this.dataTable = new DataTable();
            this.conexao.Open();
        }

        #region   DAO Prova
        public List<EventosDiario> getDataProximaProva(int matricula)
        {
            List<EventosDiario> provasProximas = new List<EventosDiario>();

            try
            {
                //String da query SQL
                this.query = " SELECT TOP 1 DIS.NOME,                                                   " +
                             "              EVD.DESCRICAO,                                              " +
                             "              EVD.DATA_INICIO                                             " +
                             " FROM PUCTBL_EVENTOS_DIARIO EVD                                           " +
                             "      JOIN PUCTBL_DIARIO DIA ON EVD.ID_DIARIO = DIA.ID_DIARIO             " +
                             "      JOIN PUCTBL_DISCIPLINA DIS ON DIA.ID_DISCIPLINA = DIS.ID_DISCIPLINA " +
                             "      JOIN PUCTBL_ALUNO ALU ON ALU.ID_CURSO = DIA.ID_CURSO                " +
                            $" WHERE ALU.MATRICULA = {matricula}                                        " +
                             "      AND EVD.ID_TIPO_EVENTO = 1                                          " +
                             "      AND EVD.DATA_INICIO >= GETDATE()                                    " +
                             " ORDER BY EVD.DATA_INICIO ASC                                             ";

                //Executa o comando SQL
                this.executaComando = new SqlCommand(query, conexao);

                //Modifica os dados de retorno para o formato DataTable
                this.retornoQuery = new SqlDataAdapter { SelectCommand = executaComando };
                this.retornoQuery.Fill(dataTable);

                //Preenche o objeto de retorno do banco
                for (int i=0; i < dataTable.Rows.Count; i++)
                {
                    provasProximas.Add(new EventosDiario { nome = dataTable.Rows[i]["NOME"].ToString(), descricao = dataTable.Rows[i]["DESCRICAO"].ToString(), dataInicio = Convert.ToDateTime(dataTable.Rows[i]["DATA_INICIO"]) });
                }

                return provasProximas;

            } 
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!this.conexao.Equals(null))
                {
                    this.conexao.Close();
                    this.conexao.Dispose();
                }
            }
        }

        public List<EventosDiario> getProvas(int matricula)
        {
            List<EventosDiario> todasProvas = new List<EventosDiario>();

            try
            {
                //String da query SQL
                this.query = " SELECT       DIS.NOME,                                                   " +
                             "              EVD.DESCRICAO,                                              " +
                             "              EVD.DATA_INICIO                                             " +
                             " FROM PUCTBL_EVENTOS_DIARIO EVD                                           " +
                             "      JOIN PUCTBL_DIARIO DIA ON EVD.ID_DIARIO = DIA.ID_DIARIO             " +
                             "      JOIN PUCTBL_DISCIPLINA DIS ON DIA.ID_DISCIPLINA = DIS.ID_DISCIPLINA " +
                             "      JOIN PUCTBL_ALUNO ALU ON ALU.ID_CURSO = DIA.ID_CURSO                " +
                            $" WHERE ALU.MATRICULA = {matricula}                                        " +
                             "      AND EVD.ID_TIPO_EVENTO = 1                                          " +
                             "      AND EVD.DATA_INICIO >= GETDATE()                                    " +
                             " ORDER BY EVD.DATA_INICIO ASC                                             ";

                //Executa o comando SQL
                this.executaComando = new SqlCommand(query, conexao);

                //Modifica os dados de retorno para o formato DataTable
                this.retornoQuery = new SqlDataAdapter { SelectCommand = executaComando };
                this.retornoQuery.Fill(dataTable);

                //Preenche o objeto de retorno do banco
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    todasProvas.Add(new EventosDiario { nome = dataTable.Rows[i]["NOME"].ToString() , descricao = dataTable.Rows[i]["DESCRICAO"].ToString() , dataInicio = Convert.ToDateTime(dataTable.Rows[i]["DATA_INICIO"]) } );
                }

                return todasProvas;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!this.conexao.Equals(null))
                {
                    this.conexao.Close();
                    this.conexao.Dispose();
                }
            }
        }
        #endregion

        #region DAO Aluno

        public Entities.Aluno getDadosCadastrais(int matricula)
        {
            Entities.Aluno alunoDados = new Entities.Aluno();

            try
            {
                //String da query SQL
                this.query = $" SELECT * FROM PUCTBL_ALUNO WHERE MATRICULA = {matricula} ";

                //Executa o comando SQL
                this.executaComando = new SqlCommand(query, conexao);

                //Modifica os dados de retorno para o formato DataTable
                this.retornoQuery = new SqlDataAdapter { SelectCommand = executaComando };
                this.retornoQuery.Fill(dataTable);

                //Preenche o objeto de retorno do banco
                alunoDados.matricula = Convert.ToInt32(dataTable.Rows[0]["MATRICULA"]);
                alunoDados.idCurso = Convert.ToInt32(dataTable.Rows[0]["ID_CURSO"]);
                alunoDados.email = dataTable.Rows[0]["EMAIL"].ToString();
                alunoDados.dataMatricula = Convert.ToDateTime(dataTable.Rows[0]["DATA_MATRICULA"]);

                if (string.IsNullOrEmpty(dataTable.Rows[0]["DATA_CONCLUSAO_CURSO"].ToString()))
                    alunoDados.dataConclusaoCurso = null;
                else
                    alunoDados.dataConclusaoCurso = Convert.ToDateTime(dataTable.Rows[0]["DATA_CONCLUSAO_CURSO"]);

                return alunoDados;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!this.conexao.Equals(null))
                {
                    this.conexao.Close();
                    this.conexao.Dispose();
                }
            }
        }

        public List<Entities.AlunoDisciplina> getDisciplinas(int matricula)
        {
            List<Entities.AlunoDisciplina> alunoDisciplinas = new List<Entities.AlunoDisciplina>();

            try
            {
                //String da query SQL
                //this.query = $" SELECT * FROM PUCTBL_ALUNO WHERE MATRICULA = {matricula} ";

                //Executa o comando SQL
                this.executaComando = new SqlCommand(query, conexao);

                //Modifica os dados de retorno para o formato DataTable
                this.retornoQuery = new SqlDataAdapter { SelectCommand = executaComando };
                this.retornoQuery.Fill(dataTable);

                //Preenche o objeto de retorno do banco
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    alunoDisciplinas.Add(new AlunoDisciplina { nomeDisciplina = dataTable.Rows[i]["NOME"].ToString() });
                }

                return alunoDisciplinas;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!this.conexao.Equals(null))
                {
                    this.conexao.Close();
                    this.conexao.Dispose();
                }
            }
        }

        #endregion

        #region DAO Professor

        public Entities.Professor getEmailProfessor(int idCurso, int idDisciplina)
        {
            Entities.Professor professorDados = new Entities.Professor();

            try
            {
                //String da query SQL
                //this.query = $" SELECT * FROM PUCTBL_ALUNO WHERE MATRICULA = {matricula} ";

                //Executa o comando SQL
                this.executaComando = new SqlCommand(query, conexao);

                //Modifica os dados de retorno para o formato DataTable
                this.retornoQuery = new SqlDataAdapter { SelectCommand = executaComando };
                this.retornoQuery.Fill(dataTable);

                //Preenche o objeto de retorno do banco
                professorDados.email = dataTable.Rows[0]["EMAIL"].ToString();

                return professorDados;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!this.conexao.Equals(null))
                {
                    this.conexao.Close();
                    this.conexao.Dispose();
                }
            }
        }

        #endregion

        #region DAO Coordenacao
        #endregion

    }
}