using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SorteioCopa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SorteioCopa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {

        [HttpGet]
        public ActionResult padrao()
        {
            return Ok("ok");
        }

        [HttpGet("ObterPaises")]

        public ActionResult ObterPaises()
        {
            var data = new CopaContex();
            var result = data.Paises.ToList();

            if(result == null)
            {
                return BadRequest("Não existe paises para listar.");
            }


            return Ok(result);
        }


    }
}
