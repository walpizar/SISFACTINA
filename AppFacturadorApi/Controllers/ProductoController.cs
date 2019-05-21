using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFacturadorApi.Controllers
{
    [Route("api/producto")]
    [ApiController]
    public class ProductoController:ControllerBase
    {

        IService<TbProducto> _ProductIns;

        public ProductoController(IService<TbProducto> ProductIns)
        {
            _ProductIns = ProductIns;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TbProducto>> Get()
        {
            try
            {
                IEnumerable<TbProducto> listaProductos = _ProductIns.ConsultarTodos();

                if (listaProductos.ToList().Count == 0)
                {
                    return NotFound();
                }

                return Ok(listaProductos);

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<TbProducto> Get(string id)
        {
            try
            {
                TbProducto producto = new TbProducto();
                producto.IdProducto = id;
                producto = _ProductIns.ConsultarById(producto);
                if (producto != null)
                {
                    return Ok(producto);
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
