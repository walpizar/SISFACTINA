using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppFacturadorApi.Controllers
{
    [Route("api/compras")]
    [ApiController]
    public class ComprasController : Controller
    {
        // inyeccion de datos
        IService<TbDocumento> _Contexto;

        public ComprasController(IService<TbDocumento> Contexto)
        {
            _Contexto = Contexto;
        }

        // constructor con inyeccion de datos


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<TbDocumento>> Get()
        {
            try
            {
                IEnumerable<TbDocumento> ListaDoc;
                ListaDoc = _Contexto.ConsultarTodos();
                ListaDoc = ListaDoc.Where(x => x.TipoDocumento == 6).ToList();
                if (ListaDoc.ToList().Count != 0)
                {
                    return Ok(ListaDoc);
                }
                return NotFound("No hay registros de compras");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpPost]
        public ActionResult<TbDocumento> Post([FromBody] TbDocumento document)
        {
            try
            {
                // campos de auditoria
                document.Fecha = DateTime.Now;
                document.FechaCrea = DateTime.Now;
                document.FechaUltMod = DateTime.Now;
                document.UsuarioCrea = Environment.UserName;
                document.UsuarioUltMod = Environment.UserName;
                bool agregado = _Contexto.Agregar(document);
                if (agregado)
                {
                    return Ok();
                }
                return BadRequest();

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
    }

    }
