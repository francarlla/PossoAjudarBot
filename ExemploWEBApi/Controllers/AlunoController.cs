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
        [Route("api/Aluno/getDadosCadastrais")]
        public async Task<IHttpActionResult> getDadosCadastrais(int matricula)
        {
            try
            {
                Entities.Aluno aluno = new Entities.Aluno();
                //Chama o serviço somente se a matricula tiver sido passada
                if (!string.IsNullOrEmpty(matricula.ToString()))
                {
                    aluno = alunoModel.getDadosCadastrais(matricula);
                    return Ok(aluno);
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
        [Route("api/Aluno/getDisciplinas")]
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

    }
}
