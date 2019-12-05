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
                this.query = " SELECT       DIS.NOME,                                                   " +
                             "              EVD.DESCRICAO,                                              " +
                             "              CONVERT(CHAR,EVD.DATA_INICIO, 103) as DATA_INICIO           " +
                             " FROM PUCTBL_EVENTOS_DIARIO EVD                                           " +
                             "      JOIN PUCTBL_DIARIO DIA ON EVD.ID_DIARIO = DIA.ID_DIARIO             " +
                             "      JOIN PUCTBL_DISCIPLINA DIS ON DIA.ID_DISCIPLINA = DIS.ID_DISCIPLINA " +
                             "      JOIN PUCTBL_ALUNO ALU ON ALU.ID_CURSO = DIA.ID_CURSO                " +
                            $" WHERE ALU.MATRICULA = {matricula}                                        " +
                             "      AND EVD.ID_TIPO_EVENTO = 1                                          " +
                             "      AND EVD.DATA_INICIO >= (SELECT TOP 1 CONVERT(DATETIME,EVD.DATA_INICIO, 103)                      " +
                             "                              FROM PUCTBL_EVENTOS_DIARIO EVD                                           " +
                             "                                  JOIN PUCTBL_DIARIO DIA ON EVD.ID_DIARIO = DIA.ID_DIARIO              " +
                             "                                  JOIN PUCTBL_DISCIPLINA DIS ON DIA.ID_DISCIPLINA = DIS.ID_DISCIPLINA  " +
                             "                                  JOIN PUCTBL_ALUNO ALU ON ALU.ID_CURSO = DIA.ID_CURSO                 " +
                            $"                              WHERE ALU.MATRICULA = {matricula}                                        " +
                             "                                  AND EVD.ID_TIPO_EVENTO = 1                                           " +
                             "                                  AND cast(EVD.DATA_INICIO as date) >= GETDATE()                       " +
                             "                              ORDER BY EVD.DATA_INICIO ASC)                                            " +
                             " ORDER BY EVD.DATA_INICIO ASC                                             ";

                //Executa o comando SQL
                this.executaComando = new SqlCommand(query, conexao);

                //Modifica os dados de retorno para o formato DataTable
                this.retornoQuery = new SqlDataAdapter { SelectCommand = executaComando };
                this.retornoQuery.Fill(dataTable);

                //Preenche o objeto de retorno do banco
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    provasProximas.Add(new EventosDiario { nome = dataTable.Rows[i]["NOME"].ToString(), descricao = dataTable.Rows[i]["DESCRICAO"].ToString(), dataInicio = dataTable.Rows[i]["DATA_INICIO"].ToString().Trim()});
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
                             "              CONVERT(CHAR,EVD.DATA_INICIO, 103) as DATA_INICIO           " +
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
                    todasProvas.Add(new EventosDiario { nome = dataTable.Rows[i]["NOME"].ToString(), descricao = dataTable.Rows[i]["DESCRICAO"].ToString(), dataInicio = dataTable.Rows[i]["DATA_INICIO"].ToString().Trim() });
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
            Entities.Aluno alunoDados = null;

            try
            {
                //String da query SQL
                this.query = $" SELECT * FROM PUCTBL_ALUNO WHERE MATRICULA = {matricula} ";

                //Executa o comando SQL
                this.executaComando = new SqlCommand(query, conexao);

                //Modifica os dados de retorno para o formato DataTable
                this.retornoQuery = new SqlDataAdapter { SelectCommand = executaComando };
                this.retornoQuery.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    alunoDados = new Entities.Aluno();
                    //Preenche o objeto de retorno do banco
                    alunoDados.matricula = Convert.ToInt32(dataTable.Rows[0]["MATRICULA"]);
                    alunoDados.idCurso = Convert.ToInt32(dataTable.Rows[0]["ID_CURSO"]);
                    alunoDados.email = dataTable.Rows[0]["EMAIL"].ToString();
                    alunoDados.dataMatricula = Convert.ToDateTime(dataTable.Rows[0]["DATA_MATRICULA"]);

                    if (string.IsNullOrEmpty(dataTable.Rows[0]["DATA_CONCLUSAO_CURSO"].ToString()))
                        alunoDados.dataConclusaoCurso = null;
                    else
                        alunoDados.dataConclusaoCurso = Convert.ToDateTime(dataTable.Rows[0]["DATA_CONCLUSAO_CURSO"]);
                }
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

        #region DAO Curso

        public Coordenacao getContatoCoordenacao(int idCurso)
        {
            Coordenacao coordenacaoDados = null;

            try
            {
                //String da query SQL
                this.query = $" SELECT PS.NOME, C.EMAIL, C.TELEFONE, C.ID_PROFESSOR, CS.NOME as CURSO" +
                             $" FROM PUCTBL_COORDENACAO C" +
                             $"     JOIN PUCTBL_PROFESSOR PF ON C.ID_PROFESSOR = PF.ID_PROFESSOR" +
                             $"     JOIN PUCTBL_PESSOA PS ON PF.ID_PESSOA = PS.ID_PESSOA" +
                             $"     JOIN PUCTBL_CURSO CS ON C.ID_CURSO = CS.ID_CURSO" +
                             $" WHERE C.ID_CURSO = {idCurso} ";

                //Executa o comando SQL
                this.executaComando = new SqlCommand(query, conexao);

                //Modifica os dados de retorno para o formato DataTable
                this.retornoQuery = new SqlDataAdapter { SelectCommand = executaComando };
                this.retornoQuery.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    coordenacaoDados = new Coordenacao();
                    //Preenche o objeto de retorno do banco
                    coordenacaoDados.idProfessor = Convert.ToInt32(dataTable.Rows[0]["ID_PROFESSOR"]);
                    coordenacaoDados.nomeCoordenador = dataTable.Rows[0]["NOME"].ToString();
                    coordenacaoDados.nomeCurso = dataTable.Rows[0]["CURSO"].ToString();
                    coordenacaoDados.email = dataTable.Rows[0]["EMAIL"].ToString();
                
                    if (string.IsNullOrEmpty(dataTable.Rows[0]["TELEFONE"].ToString()))
                        coordenacaoDados.telefone = null;
                    else
                        coordenacaoDados.telefone = Convert.ToInt32(dataTable.Rows[0]["TELEFONE"]);
                }
                return coordenacaoDados;

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

    }
}