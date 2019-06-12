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
        // constructor con inyeccion de datos


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<TbDocumento>> Get()
        {
            try
            {
                IEnumerable<TbDocumento> ListaDoc;
                ListaDoc = _Contexto.ConsultarTodos();
                if (ListaDoc.ToList().Count != 0)
                {
                    return Ok(ListaDoc);
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
