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
    [Route("api/roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
            
        IService<TbRoles> _RolesIns;

        public RolesController(IService<TbRoles> RolesIns)
        {
            _RolesIns = RolesIns;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TbRoles>> Get()
        {

            try
            {
                IEnumerable<TbRoles> listaRoles = _RolesIns.ConsultarTodos();

                if (listaRoles.ToList().Count == 0)
                {
                    return NotFound();
                }
                return Ok(listaRoles);

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }


    }
}