using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppFacturadorApi.Controllers
{
    [Route("api/exoneraciones")]
    [ApiController]
    public class IdExonercionController : Controller
    {
        IService<TbExoneraciones> _ExoneracionesIns;

        public IdExonercionController(IService<TbExoneraciones> ExoneracionesIns)
        {
            _ExoneracionesIns = ExoneracionesIns;
        }


        [HttpGet]
        public ActionResult<IEnumerable<TbExoneraciones>> Get()
        {

            try
            {
                IEnumerable<TbExoneraciones> listaExonera = _ExoneracionesIns.ConsultarTodos();
                if (listaExonera != null)
                {
                    return Ok(listaExonera);

                }
                return BadRequest();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
