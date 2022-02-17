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

        public ActionResult ObterPorId(int id )
        {
            var data = new CopaContex();
            var result = data.Cagar.FirstOrDefault(f => f.Id == id);
            return Ok(result);
        }
      
       
    }
}
