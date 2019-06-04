using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppFacturadorApi.Controllers
{
    [Route("api/personatri")]
    [ApiController]
    public class PersonaTribunalController : ControllerBase
    {
        IService<TbPersonasTribunalS> _personaTri;

        public PersonaTribunalController(IService<TbPersonasTribunalS> personaTri)
        {
            _personaTri = personaTri;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TbPersonasTribunalS>> Get()
        {
            try
            {
                IEnumerable<TbPersonasTribunalS> listaTribunal;
                listaTribunal = _personaTri.ConsultarTodos();
                if (listaTribunal != null)
                {
                    return Ok(listaTribunal);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }

        [HttpGet("{id}")]
        public ActionResult<TbPersonasTribunalS> Get(string id)
        {
            try
            {
                TbPersonasTribunalS personaTribunal = new TbPersonasTribunalS();
                personaTribunal.Id = id;
                personaTribunal = _personaTri.ConsultarById(personaTribunal);

                if (personaTribunal == null)
                {
                    return NotFound();
                }

                return Ok(personaTribunal);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }
    }
}