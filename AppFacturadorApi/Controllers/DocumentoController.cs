using AppFacturador.Api.Utilities;
using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.FacturaElectronica.ClasesDatos;
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

        Datos Datos;

        public DocumentoController(IService<TbDocumento> DocumentoIns, IService<TbInventario> inv, Datos datos)
        {
            _DocumentoIns = DocumentoIns;
            _inv = inv;
            Datos = datos;
        }

        string sucursal = "001";
        string caja = "01";
        string codigoPais = "506";


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

        // metodo para obtener documentos actuales
        [HttpGet("actuales")]
        public ActionResult<IEnumerable<TbDocumento>> GetActual()
        {

            try
            {
                IEnumerable<TbDocumento> lista = _DocumentoIns.ConsultarTodos();
                DateTime fechaActual = DateTime.Now;
                lista = lista.Where(x => x.Fecha.Date == fechaActual.Date).ToList();


                if (lista.ToList().Count == 0)
                {
                    return NotFound(false);

                }


                return Ok(lista);
            }
            catch (Exception ex)
            {

                return StatusCode(500);
            }
        }

        //Metodo para validacion en respuesta de hacienda
         
        [HttpGet("hacienda")]
        public ActionResult<IEnumerable<TbDocumento>> GetHacienda()
        {

            try
            {
                IEnumerable<TbDocumento> lista = _DocumentoIns.ConsultarTodos();                
                lista = lista.Where(x => x.Estado==true && x.EstadoFacturaHacienda==null || x.EstadoFacturaHacienda.Trim() == "rechazado" 
                || x.EstadoFacturaHacienda.Trim() == "procesando" || x.ReporteAceptaHacienda==false || 
                x.MensajeReporteHacienda==null || x.MensajeRespHacienda==null || x.MensajeRespHacienda==false).ToList();

                //lista = lista.Where(x => x.EstadoFacturaHacienda.Trim() == "rechazado" || x.EstadoFacturaHacienda.Trim() == "procesando").ToList();


                if (lista.ToList().Count == 0)
                {
                    return NotFound(false);

                }


                return Ok(lista);
            }
            catch (Exception ex)
            {

                return StatusCode(500);
            }
        }

        //Metodo para obtener las facturas de credito

        [HttpGet("consultar/{idEmpresa}")]
        public ActionResult<IEnumerable<TbDocumento>> Get(string idEmpresa)
        {

            try
            {
                IEnumerable<TbDocumento> lista = _DocumentoIns.ConsultarTodos();
                lista = lista.Where(x => x.IdEmpresa != null && x.IdEmpresa.Trim().Equals(idEmpresa) && x.EstadoFactura == 2 && x.TipoVenta == 2 ).ToList();


                if (lista.ToList().Count == 0)
                {
                    return NotFound(false);

                }


                return Ok(lista);
            }
            catch (Exception ex)
            {

                return StatusCode(500);
            }
        }

        //Metodo para obtener las facturas por fecha de forma ascendiente 

        [HttpGet("consultar/ordenfecha/{idEmpresa}")]
        public ActionResult<IEnumerable<TbDocumento>> Gett(string idEmpresa)
        {          
            
            try
            {           
                IEnumerable<TbDocumento> lista = _DocumentoIns.ConsultarTodos();
                lista = (from doc in lista
                         where doc.IdEmpresa != null && doc.IdEmpresa.Trim().Equals(idEmpresa) && doc.TipoVenta == 2 &&
                         doc.EstadoFactura == 2
                         orderby doc.Fecha ascending
                         select doc).ToList();

                if (lista.ToList().Count == 0)
                {
                    return NotFound(false);

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
        [HttpGet("correoelectronico/{correo}")]
        public ActionResult<bool> EnviaCorreoElectronico(string correo)
        {
           bool envio= Correo_Electronico.EnviarCorreo(correo);
            if (envio)
            {
                return Ok(true);
            }
            else
            {
                return NotFound(false);
            }
           
        }

        // POST api/values
        [HttpPost]
        public ActionResult<TbDocumento> Post([FromBody] TbDocumento document)
        {
            try
            {
                document.FechaCrea = DateTime.Now;
                document.FechaUltMod = DateTime.Now;
                IEnumerable<TbDocumento> listaFacturas;
                listaFacturas = _DocumentoIns.ConsultarTodos();
                //si el tipo de documento es 1, lo guarda 
                if (document.TipoDocumento == 1)
                {
                    decimal cantidad = 0;

                    document.FechaRef = DateTime.Now;
                    if (listaFacturas.ToList().Count > 0)
                    {
                        document.Id = (from fac in listaFacturas orderby fac.Id descending select fac).Take(1).SingleOrDefault().Id;
                    }

                    document.Id += 1;
                    if (document.TbDetalleDocumento.ToList().Count > 0)
                    {

                        TbInventario inventario = new TbInventario();

                        IEnumerable<TbInventario> Listinventario;
                        foreach (var item in document.TbDetalleDocumento)
                        {
                            Listinventario = _inv.ConsultarTodos();
                            cantidad = Listinventario.Where(X => X.IdProducto == item.IdProducto).SingleOrDefault().Cantidad;
                            if (item.Cantidad > cantidad)
                            {

                                return null;
                            }
                        }

                    }
                }

                else if (document.TipoDocumento == 3)
                {

                    document.UsuarioCrea = Environment.UserName;
                    document.UsuarioUltMod = Environment.UserName;
                    document.ReporteAceptaHacienda = true;
                    document.TbDetalleDocumento.Where(x => x.IdTipoDoc != 0).SingleOrDefault().IdTipoDoc = 3;

                }

                document.Consecutivo = Datos.CreaNumeroSecuencia(sucursal, caja, document.TipoDocumento.ToString(), document.Id.ToString());
                string codigo = Datos.CreaCodigoSeguridad(document.TipoDocumento.ToString(), sucursal, caja, document.Fecha, document.Id.ToString());
                document.Clave = Datos.CreaClave(codigoPais, document.Fecha.Day.ToString(), document.Fecha.Month.ToString(), document.Fecha.Year.ToString().Substring(2, 2), document.IdEmpresa.ToString(), document.Consecutivo, document.EstadoFactura.ToString(), codigo);
                if (_DocumentoIns.Agregar(document) == true)
                {
                    listaFacturas = _DocumentoIns.ConsultarTodos();                    
                    return Ok((from fac in listaFacturas orderby fac.Id descending select fac).Take(1).SingleOrDefault());
                }

                return BadRequest();
            }
            catch (Exception ex)
            {

                return NotFound();
            }
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult<bool> Put([FromBody] TbDocumento Doc)
        {
            try
            {
                bool modifico = _DocumentoIns.Modificar(Doc);

                if (modifico)
                {
                    return Ok(true);
                }
                else
                {
                    return NotFound(false);
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
        private void crearConsecutivo()
        {

        }
    }
}
