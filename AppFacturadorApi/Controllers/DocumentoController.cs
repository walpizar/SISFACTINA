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

        public DocumentoController(IService<TbDocumento> DocumentoIns)
        {
            _DocumentoIns = DocumentoIns;
        }

        // GET api/values
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
        public ActionResult Post([FromBody] TbDocumento document)
        {
            try
            {
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
