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



        [HttpPost("AdicionarPais")]
        public ActionResult AdicionarPais(paises paises)
        {
            var data = new CopaContex();
            var exists = data.Paises.FirstOrDefault(f => f.ID == paises.ID);

            if(exists == null)
            {
                data.Paises.Add(paises);
                data.SaveChanges();
                return Ok("Pais cadastrado com sucesso!!");
            }
            return BadRequest("Pais ja existe na base de dados.");
        }



        [HttpDelete("DeletarPais/{Id}")]

        public ActionResult DeletearPais(int Id)
        {
            var data = new CopaContex();
            var exists = data.Paises.FirstOrDefault(f => f.ID == Id);

            if (exists != null)
            {
                data.Paises.Remove(exists);
                data.SaveChanges();
                return Ok("Pais excluido com sucesso!!!!!");
            }

            return BadRequest("Não é possivel deletar pois pais não existe.");
        }
    }
}
