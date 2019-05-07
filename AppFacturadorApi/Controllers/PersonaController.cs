using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFacturadorApi.Controllers
{
    [Route("api/persona")]
    [ApiController]
    public class PersonaController:ControllerBase
    {
        IService<TbPersona> _PersonaIns;

        public PersonaController(IService<TbPersona> PersonaIns)
        {
            _PersonaIns = PersonaIns;
        }
       

        //GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<TbPersona> Get(int id)
        {
            try
            {
                TbPersona Persona = new TbPersona();
                Persona.Identificacion = id.ToString();
                Persona = _PersonaIns.ConsultarById(Persona);
                if (Persona == null)
                {
                    return NotFound("No se encontro ningun Persona");
                }


                return Ok(Persona);
            }
            catch (Exception ex)
            {

                return StatusCode(500);
            }

        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] TbPersona Persona)
        {
            try
            {
                bool guardo = _PersonaIns.Agregar(Persona);
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
        public ActionResult Put([FromBody] TbPersona value)
        {
            try
            {
                bool modifico = _PersonaIns.Modificar(value);

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
                TbPersona Persona = new TbPersona();
                Persona.Identificacion = id.ToString();
                Persona = _PersonaIns.ConsultarById(Persona);
                bool elimino = _PersonaIns.Eliminar(Persona);
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
