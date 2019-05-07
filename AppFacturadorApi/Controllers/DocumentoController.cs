using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFacturadorApi.Controllers
{
    [Route("api/documento")]
    [ApiController]
    public class DocumentoController:ControllerBase
    {
        IService<TbDocumento> _DocumentoIns;

        public DocumentoController(IService<TbDocumento> DocumentoIns)
        {
            _DocumentoIns = DocumentoIns;
        }

        // GET api/values
        [HttpGet("consultar/{idCliente}")]
        public ActionResult<IEnumerable<TbDocumento>> Get(string idCliente)
        {
            //string idCliente = "603480811";
            try
            {
                IEnumerable<TbDocumento> lista = _DocumentoIns.ConsultarTodos(idCliente);
                if (lista.ToList().Count == 0)
                {
                    return NotFound();

                }
                //foreach (var item in lista)
                //{
                //    //item.TipoMonedaNavigation.TbDocumento.Remove(item);


                //    //item.TipoPagoNavigation.TbDocumento.Remove(item);
                //    //item.TipoVentaNavigation.TbDocumento.Remove(item);
                //    //item.TbClientes.TbDocumento.Remove(item);
                //    item.TbClientes.TbPersona.TbClientes = null;
                //    foreach (var ite in item.TbDetalleDocumento)
                //    {
                //        ite.Id = null;
                //    }
                //}
               

                return Ok(lista);
            }
            catch (Exception ex)
            {

                return StatusCode(500);
            }
        }

        //GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<TbDocumento> Get(int id)
        {
            try
            {
                TbDocumento Documento = new TbDocumento();
                Documento.Id = id;
                Documento = _DocumentoIns.ConsultarById(Documento);
                if (Documento == null)
                {
                    return NotFound("No se encontro ningun Documento");
                }


                return Ok(Documento);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] TbDocumento Documento)
        {
            try
            {
                bool guardo = _DocumentoIns.Agregar(Documento);
                if (guardo)
                {
                    return Ok("Se agrego Correctamente");
                }
                else
                {
                    return NotFound("ERROR SERVICIO");
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] TbDocumento value)
        {
            try
            {
                bool modifico = _DocumentoIns.Modificar(value);

                if (modifico)
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

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                TbDocumento Documento = new TbDocumento();
                Documento.Id = id;
                Documento = _DocumentoIns.ConsultarById(Documento);
                bool elimino = _DocumentoIns.Eliminar(Documento);
                if (elimino)
                {
                    return Ok("Se elimino correctamente");
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
    }
}
