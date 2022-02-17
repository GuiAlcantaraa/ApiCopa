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


        [HttpGet("ObterConfederacao/{Id}")]

        public ActionResult ObterPorId(int Id)
        {
            var data = new CopaContex();
            var result = data.Cagar.ToList();

            if(result == null)
            {
                return BadRequest("Cagar não existe na base de datos");
            }
            return Ok(result);
        }


        [HttpPost("AdicionarCagar")]

        public ActionResult AdicionarCagar(cagar cagar)
        {

            var data = new CopaContex();
            var exists = data.Cagar.FirstOrDefault(f => f.Id == cagar.Id);

            if (exists == null)
            {
                data.Cagar.Add(cagar);
                data.SaveChanges();
                return Ok("Produto cadastrado");
            }

            return BadRequest("Ja existe");

        }
       
    }
}
