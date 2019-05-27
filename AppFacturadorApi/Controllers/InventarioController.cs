using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFacturadorApi.Controllers
{
    
        [Route("api/inventario")]
        [ApiController]
        public class InventarioController : ControllerBase
        {
            IService<TbInventario> _inv ;

            public InventarioController(IService<TbInventario> inv)
            {
                _inv = inv;
            }


            // GET api/values
            [HttpGet]
            public ActionResult<IEnumerable<TbInventario>> Get()
            {
                try
                {
                    IEnumerable<TbInventario> ListaTbInventarios;
                    ListaTbInventarios = _inv.ConsultarTodos();
                    if (ListaTbInventarios.ToList().Count != 0)
                    {
                        return Ok(ListaTbInventarios);
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
            public ActionResult<TbInventario> Get(string id)
            {
                try
                {
                    TbInventario Inventario = new TbInventario();
                Inventario.IdProducto = id;
                Inventario = _inv.ConsultarById(Inventario);
                    if (Inventario != null)
                    {
                        return Ok(Inventario);
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
            public ActionResult<bool> Post([FromBody] TbInventario Inventario)
            {
                try
                {
                    
                    if (_inv.Agregar(Inventario) == true)
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
            public ActionResult<TbInventario> Put([FromBody] TbInventario Inventario)
            {
                try
                {
                    Inventario.FechaUltMod = DateTime.MinValue;

                    if (_inv.Modificar(Inventario) == true)
                    {
                        return Ok(true);
                    }
                    return NotFound();
                }
                catch (Exception ex)
                {

                    return StatusCode(500);
                }
            }

            // DELETE api/values/5
            [HttpDelete("{id}")]
            public ActionResult<TbInventario> Delete(string id)
            {
                try
                {
                    TbInventario Inventario = new TbInventario();
                    Inventario.IdProducto = id;
                    Inventario =_inv.ConsultarById(Inventario);
                    Inventario.Estado = false;
                    if (_inv.Eliminar(Inventario) == true)
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

