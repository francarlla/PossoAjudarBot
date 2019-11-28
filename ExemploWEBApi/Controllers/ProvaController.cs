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

namespace ExemploWEBApi.Controllers
{
    public class ProvaController : ApiController
    {
        private Prova provaModel = new Prova();

        [HttpGet]
        [Route("api/Prova/getDataProximaProva")]
        public async Task<IHttpActionResult> getDataProximaProva(int matricula)
        {
            List<EventosDiario> provas = new List<EventosDiario>();
            string mensagem = "Sua(s) próxima(s) prova(s) será(ao): ";
            try
            {

                //Chama o serviço somente se a matricula tiver sido passada
                if (!string.IsNullOrEmpty(matricula.ToString()))
                {
                    provas = provaModel.getDataProximaProva(matricula);
                    foreach (var item in provas)

                        mensagem = mensagem + "\nDiscipplina: " + item.nome + " \nData: " + item.dataInicio.Value.ToShortDateString();
                    // var response = await 
                    return Ok(mensagem);
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
        [Route("api/Prova/getProvas")]
        public async Task<IHttpActionResult> getProvas(int matricula)
        {
            try
            {
                //Chama o serviço somente se a matricula tiver sido passada
                if (!string.IsNullOrEmpty(matricula.ToString()))
                {
                    return Ok(provaModel.getProvas(matricula));
                }
                else
                    return BadRequest("Matrícula necessária para esse serviço!");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // GET: api/Prova/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Prova
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Prova/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Prova/5
        public void Delete(int id)
        {
        }
    }
}
