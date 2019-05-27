using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFacturadorApi.Controllers
{
    [Route("api/detalle")]
    [ApiController]
    public class DetalleDocumentoController : ControllerBase
    {
        IService<TbDetalleDocumento> _detalleIns;

        public DetalleDocumentoController(IService<TbDetalleDocumento> detalleIns)
        {
            _detalleIns = detalleIns;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<TbDetalleDocumento>> Get(int id)
        {
            string idDoc = id.ToString();
            try
            {

                IEnumerable<TbDetalleDocumento> listaDetalle = _detalleIns.ConsultarTodos();
                if (listaDetalle.ToList().Count == 0)
                {
                    return NotFound();
                }
                return Ok(listaDetalle);

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }


    }
}
