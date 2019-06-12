using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFacturadorApi.Controllers
{
    //API REALLLLL

    [Route("api/producto")]
    [ApiController]
    public class productoController : ControllerBase
    {
        IService<TbProducto> _productoIns;
        IService<TbImpuestos> _impuestoIns;

        public productoController(IService<TbProducto> productoIns, IService<TbImpuestos> impuestoIns)
        {
            _productoIns = productoIns;
            _impuestoIns = impuestoIns;
        }

        [HttpGet("{id}")]
        public ActionResult<TbProducto> Get(string id)
        {
            try
            {
                TbProducto produ = new TbProducto();
                produ.IdProducto = id.ToString();
                produ = _productoIns.ConsultarById(produ);
                if (produ == null)
                {
                    return NotFound("no se encontro ningun producto");
                }
                else
                {
                    return Ok(produ);
                }

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<TbProducto>> get()
        {

            try
            {

                IEnumerable<TbProducto> lista = _productoIns.ConsultarTodos();

                List<TbProducto> listaProductos = new List<TbProducto>();

                foreach (var item in lista)
                {

                    if (item.Estado == true)
                    {
                        listaProductos.Add(item);
                    }

                }

                return Ok(listaProductos);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }

        [HttpPost]
        public ActionResult post([FromBody] TbProducto pro)
        {

            IEnumerable<TbImpuestos> listaImpuestos = _impuestoIns.ConsultarTodos();
            int impuesto = pro.IdTipoImpuesto;

            foreach (var item in listaImpuestos)
            {
                if (item.Valor == pro.IdTipoImpuesto)
                {
                    pro.IdTipoImpuesto = item.Id;
                    break;
                }
            }

            pro.Estado = true;

            pro.PrecioUtilidad1 = pro.PrecioReal + ((pro.Utilidad1Porc / 100) * pro.PrecioReal);
            pro.PrecioUtilidad2 = pro.PrecioReal + ((pro.Utilidad2Porc / 100) * pro.PrecioReal);
            pro.PrecioUtilidad3 = pro.PrecioReal + ((pro.Utilidad3Porc / 100) * pro.PrecioReal);

            pro.PrecioVenta1 = (decimal)pro.PrecioUtilidad1 + ((decimal)pro.PrecioUtilidad1 * ((decimal)impuesto / 100));
            pro.PrecioVenta2 = (decimal)pro.PrecioUtilidad2 + ((decimal)pro.PrecioUtilidad2 * ((decimal)impuesto / 100));
            pro.PrecioVenta3 = (decimal)pro.PrecioUtilidad3 + ((decimal)pro.PrecioUtilidad3 * ((decimal)impuesto / 100));


            pro.UsuarioCrea = "Juan";
            pro.UsuarioUltMod = "Juan";
            pro.FechaCrea = DateTime.Now;
            pro.FechaUltMod = DateTime.Now;

            decimal Cantidad = pro.IdProductoNavigation.Cantidad;
            decimal CantMin = (decimal)pro.IdProductoNavigation.CantMin;
            decimal CantMax = (decimal)pro.IdProductoNavigation.CantMax;

            TbInventario inve = new TbInventario();
            inve.IdProducto = pro.IdProducto;
            inve.Cantidad = Cantidad;
            inve.CantMin = CantMin;
            inve.CantMax = CantMax;
            inve.FechaCrea = DateTime.Now;
            inve.FechaUltMod = DateTime.Now;
            inve.UsuarioCrea = "Juan";
            inve.UsuarioUltMod = "Juan";
            pro.IdProductoNavigation = inve;
            bool guardo = _productoIns.Agregar(pro);


            try
            {
                if (guardo)
                {
                    return Ok();
                }

                return NotFound();

            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }

        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        {
            try
            {
                TbProducto produ = new TbProducto();
                produ.IdProducto = id.ToString();
                produ = _productoIns.ConsultarById(produ);

                bool elimino = _productoIns.Eliminar(produ);

                if (elimino)
                {
                    return Ok();
                }

                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }

        [HttpPut]
        public ActionResult Put([FromBody] TbProducto pro)
        {
            try
            {
                IEnumerable<TbImpuestos> listaImpuestos = _impuestoIns.ConsultarTodos();
                decimal impuesto = (decimal)pro.IdTipoImpuesto;

                foreach (var item in listaImpuestos)
                {
                    if (item.Valor == impuesto)
                    {
                        pro.IdTipoImpuesto = item.Id;
                    }
                }


                pro.Estado = true;

                pro.PrecioUtilidad1 = pro.PrecioReal + ((pro.Utilidad1Porc / 100) * pro.PrecioReal);
                pro.PrecioUtilidad2 = pro.PrecioReal + ((pro.Utilidad2Porc / 100) * pro.PrecioReal);
                pro.PrecioUtilidad3 = pro.PrecioReal + ((pro.Utilidad3Porc / 100) * pro.PrecioReal);

                pro.PrecioVenta1 = (decimal)pro.PrecioUtilidad1 + ((decimal)pro.PrecioUtilidad1 * (impuesto / 100));
                pro.PrecioVenta2 = (decimal)pro.PrecioUtilidad2 + ((decimal)pro.PrecioUtilidad2 * (impuesto / 100));
                pro.PrecioVenta3 = (decimal)pro.PrecioUtilidad3 + ((decimal)pro.PrecioUtilidad3 * (impuesto / 100));


                pro.UsuarioUltMod = "walter";
                pro.FechaUltMod = DateTime.Now;

                decimal Cantidad = pro.IdProductoNavigation.Cantidad;
                decimal CantMin = (decimal)pro.IdProductoNavigation.CantMin;
                decimal CantMax = (decimal)pro.IdProductoNavigation.CantMax;

                TbInventario inve = new TbInventario();
                inve.IdProducto = pro.IdProducto;
                inve.Cantidad = Cantidad;
                inve.CantMin = CantMin;
                inve.CantMax = CantMax;
                inve.UsuarioCrea = pro.UsuarioCrea;
                inve.FechaCrea = pro.FechaCrea;
                inve.FechaUltMod = DateTime.Now;
                inve.UsuarioUltMod = "walter";
                pro.IdProductoNavigation = inve;

                bool modifico = _productoIns.Modificar(pro);

                if (modifico)
                {
                    return Ok("");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                return StatusCode(500); ;
            }

        }

    }
}
