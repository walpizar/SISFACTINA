using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFacturadorApi.Controllers
{
    [Route("api/tipopago")]
    [ApiController]
    public class TbTipoPagoController : ControllerBase
    {
        IService<TbTipoPago> _cli;

        public TbTipoPagoController(IService<TbTipoPago> cli)
        {
            _cli = cli;
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<TbTipoPago>> Get()
        {
            try
            {
                IEnumerable<TbTipoPago> ListaTbTipoPagos;
                ListaTbTipoPagos= _cli.ConsultarTodos();
                if (ListaTbTipoPagos.ToList().Count!=0)
                {
                    return Ok(ListaTbTipoPagos);
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
        public ActionResult<TbTipoPago> Get(int id)
        {
            try
            {
                TbTipoPago TbTipoPago = new TbTipoPago();
                TbTipoPago.Id = id;

                TbTipoPago = _cli.ConsultarById(TbTipoPago);
                if (TbTipoPago != null)
                {

                    return Ok(TbTipoPago);
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
        public ActionResult<bool> Post([FromBody] TbTipoPago TbTipoPago)
        {
            
                try
                {
                    
                    if (_cli.Agregar(TbTipoPago) == true)
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
        public ActionResult<TbTipoPago> Put([FromBody] TbTipoPago TbTipoPago)
        {
            try
            {

                if ( _cli.Modificar(TbTipoPago)== true)
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
        public ActionResult<TbTipoPago> Delete(int id)
        {
            try
            {
                TbTipoPago TbTipoPago = new TbTipoPago();
                TbTipoPago.Id = id;
                TbTipoPago = _cli.ConsultarById(TbTipoPago);
                if (_cli.Eliminar(TbTipoPago) == true)
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
