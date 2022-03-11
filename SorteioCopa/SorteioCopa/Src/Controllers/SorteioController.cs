using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SorteioCopa.Data;
using System.Linq;

namespace SorteioCopa.Src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SorteioController : ControllerBase
    {

        [HttpGet("Sorteio")]
        public ActionResult Sorteio()
        {

            var data = new CopaContex();
            var result = data.Paises.FirstOrDefault(f => f.Sede == true);

            if(result != null)
            {

            }


            return Ok(result);
        }



    }
}
