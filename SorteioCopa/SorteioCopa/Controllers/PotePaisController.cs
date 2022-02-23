using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SorteioCopa.Data;
using SorteioCopa.Models;
using System.Linq;

namespace SorteioCopa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PotePaisController : ControllerBase
    {

        [HttpGet]

        public ActionResult Padrao()
        {
            return Ok("OK");
        }

        [HttpGet("ObterPotePais")]

        public ActionResult ObterPorId()
        {
            var data = new CopaContex();
            var result = data.PotePais.ToList();

            if (result == null)
            {
                return BadRequest("Não existe confederações na base de dados.");
            }
            return Ok(result);
        }

        [HttpPost("AdicionarPaisNoPote")]

        public ActionResult AdicionarPaisNoPote(PotePais potepais)
        {

            var data = new CopaContex();
            var exists = data.PotePais.FirstOrDefault(f => f.Id == potepais.Id);

            if (exists == null)
            {
                data.PotePais.Add(potepais);
                data.SaveChanges();
                return Ok("Pais cadastrado no pote com sucesso!!!");
            }

            return BadRequest("Error.");

        }

    }
}
