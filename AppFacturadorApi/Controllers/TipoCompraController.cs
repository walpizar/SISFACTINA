using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFacturadorApi.Controllers
{
    [Route("api/tipoventa")]
    [ApiController]
    public class TbTipoVentaController : ControllerBase
    {
        IService<TbTipoVenta> _tpId;

        public TbTipoVentaController(IService<TbTipoVenta> tpId)
        {
            _tpId = tpId;
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<TbTipoVenta>> Get()
        {
            try
            {
                IEnumerable<TbTipoVenta> ListaTbTipoVentas;
                ListaTbTipoVentas= _tpId.ConsultarTodos();
                if (ListaTbTipoVentas.ToList().Count!=0)
                {
                    return Ok(ListaTbTipoVentas);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<TbTipoVenta> Get(int id)
        {
            try
            {
                TbTipoVenta TbTipoVenta = new TbTipoVenta();
                TbTipoVenta.Id = id;
               
                TbTipoVenta = _tpId.ConsultarById(TbTipoVenta);
                if (TbTipoVenta != null)
                {
                    return Ok(TbTipoVenta);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }

        // POST api/values
        [HttpPost]
        public ActionResult<bool> Post([FromBody] TbTipoVenta TbTipoVenta)
        {
            
                try
                {
                    
                    if (_tpId.Agregar(TbTipoVenta) == true)
                    {
                        return Ok(true);
                    }
                    return NotFound();
                }
                catch (Exception)
                {

                    return StatusCode(500);
                }

            
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult<TbTipoVenta> Put([FromBody] TbTipoVenta TbTipoVenta)
        {
            try
            {

                if ( _tpId.Modificar(TbTipoVenta)== true)
                {
                    return Ok(true);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        // DELETE api/values/5/2
        [HttpDelete("{id}")]
        public ActionResult<TbTipoVenta> Delete(int id)
        {
            try
            {
                TbTipoVenta TbTipoVenta = new TbTipoVenta();
                TbTipoVenta.Id = id;
                TbTipoVenta = _tpId.ConsultarById(TbTipoVenta);
                if (_tpId.Eliminar(TbTipoVenta) == true)
                {
                    return Ok(true);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

    }
}
