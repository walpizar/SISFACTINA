using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFacturadorApi.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class TbClientesController : ControllerBase
    {
        IService<TbClientes> _cli;

        public TbClientesController(IService<TbClientes> cli)
        {
            _cli = cli;
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<TbClientes>> Get()
        {
            try
            {
                IEnumerable<TbClientes> ListaTbClientess;
                ListaTbClientess= _cli.ConsultarTodos();
                if (ListaTbClientess.ToList().Count!=0)
                {
                    return Ok(ListaTbClientess);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
            
        }

        // GET api/values/5
        [HttpGet("{id}/{TipoId}")]
        public ActionResult<TbClientes> Get(string id,int TipoId)
        {
            try
            {
                TbClientes TbClientes = new TbClientes();
                TbClientes.Id = id;
                TbClientes.TipoId = TipoId;
                TbClientes = _cli.ConsultarById(TbClientes);
                if (TbClientes != null)
                {


                    TbClientes.TbPersona.TbBarrios.TbPersona = null;
                    TbClientes.TbPersona.TbBarrios.TbDistrito.TbBarrios = null;
                    TbClientes.TbPersona.TbBarrios.TbDistrito.TbCanton.TbDistrito = null;
                    TbClientes.TbPersona.TbBarrios.TbDistrito.TbCanton.ProvinciaNavigation.TbCanton = null;
                    TbClientes.TbPersona.TbClientes = null;
                    return Ok(TbClientes);
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
        public ActionResult<bool> Post([FromBody] TbClientes TbClientes)
        {
            
                try
                {
                    
                    if (_cli.Agregar(TbClientes) == true)
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
        public ActionResult<TbClientes> Put([FromBody] TbClientes TbClientes)
        {
            try
            {

                if ( _cli.Modificar(TbClientes)== true)
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
        [HttpDelete("{id},{TipoId}")]
        public ActionResult<TbClientes> Delete(string id)
        {
            try
            {
                TbClientes TbClientes = new TbClientes();
                TbClientes.Id = id;
                TbClientes = _cli.ConsultarById(TbClientes);
                TbClientes.Estado = false;
                if (_cli.Eliminar(TbClientes) == true)
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
