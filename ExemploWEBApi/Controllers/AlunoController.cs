using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExemploWEBApi.Models;
using System.Threading.Tasks;

namespace ExemploWEBApi.Controllers
{
    public class AlunoController : ApiController
    {
        private Aluno alunoModel = new Aluno();

        [HttpGet]
        [Route("api/Prova/getDadosCadastrais")]
        public async Task<IHttpActionResult> getDadosCadastrais(int matricula)
        {
            try
            {
                //Chama o serviço somente se a matricula tiver sido passada
                if (!string.IsNullOrEmpty(matricula.ToString()))
                {
                    return Ok(alunoModel.getDadosCadastrais(matricula));
                }
                else
                    return BadRequest("Matrícula necessária para esse serviço!");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        [Route("api/Prova/getDisciplinas")]
        public async Task<IHttpActionResult> getDisciplinas(int matricula)
        {
            try
            {
                //Chama o serviço somente se a matricula tiver sido passada
                if (!string.IsNullOrEmpty(matricula.ToString()))
                {
                    return Ok(alunoModel.getDisciplinas(matricula));
                }
                else
                    return BadRequest("Matrícula necessária para esse serviço!");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // GET: api/Aluno/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Aluno
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Aluno/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Aluno/5
        public void Delete(int id)
        {
        }
    }
}
