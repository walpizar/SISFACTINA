using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFacturadorApi.Controllers
{
    [Route("api/distrito")]
    [ApiController]

    public class DistritoController:ControllerBase
    {
        IService<TbDistrito> _DistritoIns;

        public DistritoController(IService<TbDistrito> DistritoIns)
        {
            _DistritoIns = DistritoIns;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TbDistrito>> Get()
        {

            try
            {
                IEnumerable<TbDistrito> listaDistrito = _DistritoIns.ConsultarTodos();

                if (listaDistrito.ToList().Count == 0)
                {
                    return NotFound();
                }
                return Ok(listaDistrito);

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
    }
}
