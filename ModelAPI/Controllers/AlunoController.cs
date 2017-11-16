using ModelAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ModelAPI.Controllers
{
    public class AlunoController : ApiController
    {
        // POST: Aluno/Adicionar/
        [HttpPost]
        [Route("Aluno/Adicionar/")]
        public IHttpActionResult Adicionar(List<Aluno> alunos)
        {
            try
            {
                var retorno = new Aluno().Adicionar(alunos);
                return Ok(retorno);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        // GET: Aluno/Consultar
        [HttpGet]
        [Route("Aluno/Consultar")]
        public IHttpActionResult Consultar()
        {
            try
            {
                var retorno = new Aluno().Consultar();
                return Ok(retorno);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        // GET: Aluno/Consultar/8
        [HttpGet]
        [Route("Aluno/Consultar/{id=0}")]
        public IHttpActionResult Consultar(int id)
        {
            try
            {
                var retorno = new Aluno().ConsultarPorId(id);
                return Ok(retorno);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        // DELETE: Aluno/Delete/8
        [HttpGet]
        [Route("Aluno/Delete/{id=0}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var retorno = new Aluno().Apagar(id);
                return Ok(retorno);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
