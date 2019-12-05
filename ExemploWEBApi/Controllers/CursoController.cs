using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExemploWEBApi.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using ExemploWEBApi.Entities;
using System.Net.Http.Formatting;

namespace ExemploWEBApi.Controllers
{
    public class CursoController : ApiController
    {
        private Models.Curso cursoModel = new Models.Curso();

        [HttpGet]
        [Route("api/Curso/getContatoCoordenacao")]
        public async Task<IHttpActionResult> getContatoCoordenacao(int idCurso)
        {
            try
            {
                Coordenacao coordenacao = new Coordenacao();
                //Chama o serviço somente se a matricula tiver sido passada
                if (!string.IsNullOrEmpty(idCurso.ToString()))
                {
                    coordenacao = cursoModel.getContatoCoordenacao(idCurso);
                    return Ok(coordenacao);
                }
                else
                    return BadRequest("Código do curso é necessário para esse serviço!");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
