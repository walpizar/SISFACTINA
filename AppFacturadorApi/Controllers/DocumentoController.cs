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
    public class DocumentoController : ControllerBase
    {
        IService<TbDocumento> _DocumentoIns;
        IService<TbInventario> _inv;

        public DocumentoController(IService<TbDocumento> DocumentoIns, IService<TbInventario> inv)
        {
            _DocumentoIns = DocumentoIns;
            _inv = inv;
        }


        // GET api/values

        [HttpGet]
        public ActionResult<IEnumerable<TbDocumento>> Get()
        {
            
            try
            {
                IEnumerable<TbDocumento> listaDocumentos = _DocumentoIns.ConsultarTodos();
                if (listaDocumentos != null)
                {
                    return Ok(listaDocumentos);

                }
                return BadRequest();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpGet("consultar/{idCliente}")]
        public ActionResult<IEnumerable<TbDocumento>> Get(string idCliente)
        {

            try
            {
                IEnumerable<TbDocumento> lista = _DocumentoIns.ConsultarTodos();
                lista = lista.Where(x => x.IdCliente != null && x.TipoIdCliente != null && x.IdCliente.Trim().Equals(idCliente) && x.EstadoFactura == 2 && x.TipoVenta == 2).ToList();


                if (lista.ToList().Count == 0)
                {
                    return NotFound();

                }


                return Ok(lista);
            }
            catch (Exception ex)
            {

                return StatusCode(500);
            }
        }
        [HttpGet("consultar/ordenfecha/{idCliente}")]
        public ActionResult<IEnumerable<TbDocumento>> Gett(string idCliente)
        {
           
            try
            {
                IEnumerable<TbDocumento> lista = _DocumentoIns.ConsultarTodos();
                lista = (from doc in lista
                         where doc.IdCliente != null && doc.IdCliente.Trim().Equals(idCliente) && doc.TipoVenta == 2 &&
                         doc.EstadoFactura == 2
                         orderby doc.Fecha ascending
                         select doc).ToList();



                if (lista.ToList().Count == 0)
                {
                    return NotFound();

                }



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
        public ActionResult<bool> Post([FromBody] TbDocumento document)
        {
            try
            {
                //si el tipo de documento es 1, lo guarda 
                if (document.TipoDocumento == 1)
                {
                    decimal cantidad = 0;
                    IEnumerable<TbDocumento> listaFacturas;
                    document.FechaRef = DateTime.Now;
                    listaFacturas = _DocumentoIns.ConsultarTodos();
                    document.Id = (from fac in listaFacturas orderby fac.Id descending select fac).Take(1).SingleOrDefault().Id + 1;

                    if (document.TbDetalleDocumento.ToList().Count > 0)
                    {

                        TbInventario inventario = new TbInventario();

                        IEnumerable<TbInventario> Listinventario;
                        foreach (var item in document.TbDetalleDocumento)
                        {
                            Listinventario = _inv.ConsultarTodos();
                            cantidad = Listinventario.Where(X => X.IdProducto == item.IdProducto).SingleOrDefault().Cantidad;
                            if (item.Cantidad >= cantidad)
                            {

                                return false;
                            }
                        }

                        if (_DocumentoIns.Agregar(document) == true)
                        {
                            //foreach (var item in document.TbDetalleDocumento)
                            //{
                            //    inventario.IdProducto = item.IdProducto;
                            //    inventario = _inv.ConsultarById(inventario);
                            //    inventario.Cantidad -= item.Cantidad;
                            //    _inv.Modificar(inventario);
                            //}

                            return Ok(true);
                        }

                    }
                    return NotFound();
                }
                document.FechaCrea = DateTime.Now;
                document.FechaUltMod = DateTime.Now;
                document.UsuarioCrea = Environment.UserName;
                document.UsuarioUltMod = Environment.UserName;
                document.ReporteAceptaHacienda = true;
                document.TbDetalleDocumento.Where(x => x.IdTipoDoc != 0).SingleOrDefault().IdTipoDoc = 3;

                // agregar la Nota de credito 
                bool agregado = _DocumentoIns.Agregar(document);

                if (agregado)
                {
                    return Ok();
                }


                return BadRequest();
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] TbDocumento Doc)
        {
            try
            {
                bool modifico = _DocumentoIns.Modificar(Doc);

                if (modifico)
                {
                    return Ok("Se Modifico Correctamente");
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
