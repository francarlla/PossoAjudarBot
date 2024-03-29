﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExemploWEBApi.Models;
using System.Threading.Tasks;
using ExemploWEBApi.Entities;

namespace ExemploWEBApi.Controllers
{
    public class ProfessorController : ApiController
    {
        private Models.Professor professorModel = new Models.Professor();

        [HttpGet]
        [Route("api/Prova/getEmailProfessor")]
        public async Task<IHttpActionResult> getEmailProfessor(int idCurso, int idDisciplina)
        {
           
            try
            {
                //Chama o serviço somente se a matricula tiver sido passada
                if (!string.IsNullOrEmpty(idCurso.ToString()))
                {
                    return Ok(professorModel.getEmailProfessor(idCurso, idDisciplina));
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
