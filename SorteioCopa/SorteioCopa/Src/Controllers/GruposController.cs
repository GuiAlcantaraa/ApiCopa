using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SorteioCopa.Data;
using System.Linq;

namespace SorteioCopa.Src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GruposController : ControllerBase
    {

        [HttpGet]
        public ActionResult Ok()
        {
            return Ok("Ola");
        }


        [HttpGet("ObterGrupos")]
        public ActionResult ObterGrupos()
        {
            var data = new CopaContex();
            var result = data.Grupos.ToList();

            if (result == null) return BadRequest("Não existe grupos para listar");


            return Ok(result);
        }

        [HttpGet("ObterGrupoPais")]

        public ActionResult ObterGrupoPais()
        {
            var data = new CopaContex();
            var result = data.GrupoPais.ToList();

            return Ok(result);
        }




    }
}
