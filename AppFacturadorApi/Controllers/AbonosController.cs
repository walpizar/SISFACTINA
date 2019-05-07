using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFacturadorApi.Controllers
{
    [Route("api/abonos")]
    [ApiController]
    public class AbonosController : ControllerBase
    {
        IService<TbAbonos> _AbonosIns;

        public AbonosController(IService<TbAbonos> AbonosIns)
        {
            _AbonosIns = AbonosIns;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<TbAbonos>> Get(int id)
        {

            string IdDoc = id.ToString();
            try
            {
                IEnumerable<TbAbonos> listaAbonos = _AbonosIns.ConsultarTodos(IdDoc);

                if (listaAbonos.ToList().Count == 0)
                {
                    return NotFound();
                }
                return Ok(listaAbonos);
              
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] TbAbonos Abono)
        {
            try
            {
                bool agrego = _AbonosIns.Agregar(Abono);
                if (agrego!=true)
                {
                     return NotFound();
                    
                }
                return Ok("Se agrego Correctamente");
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
           
        }
        [HttpPut]
        public ActionResult Put([FromBody] TbAbonos Abono)
        {
            try
            {
                bool modifico = _AbonosIns.Modificar(Abono);
                if (modifico != true)
                {
                    return NotFound();
                }

                return Ok("Se modifico correctamente");
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
    }
}
