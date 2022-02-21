using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SorteioCopa.Data;
using SorteioCopa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SorteioCopa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfederacaoController : ControllerBase
    {

        [HttpGet]
        public ActionResult Ola()
        {
            return Ok("ola");
        }


        [HttpGet("ObterConfederacoes")]

        public ActionResult ObterPorId()
        {
            var data = new CopaContex();
            var result = data.Confederacao.ToList();

            if(result == null)
            {
                return BadRequest("Não existe confederações na base de dados.");
            }
            return Ok(result);
        }


        [HttpPost("AdicionarConfederacao")]

        public ActionResult AdicionarConfederacao(confederacao confederacao)
        {

            var data = new CopaContex();
            var exists = data.Confederacao.FirstOrDefault(f => f.IdConfederacao == confederacao.IdConfederacao);

            if (exists == null)
            {
                data.Confederacao.Add(confederacao);
                data.SaveChanges();
                return Ok("Confederação cadastrada!!");
            }

            return BadRequest("Confederação Ja existe na base de dados.");

        }
       
    }
}
