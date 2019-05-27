using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFacturadorApi.Controllers
{
    [Route("api/canton")]
    [ApiController]
    public class CantonController:ControllerBase
    {
        IService<TbCanton> _CantonIns;

        public CantonController(IService<TbCanton> CantonIns)
        {
            _CantonIns = CantonIns;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TbCanton>> Get()
        {


            try
            {
                IEnumerable<TbCanton> listaCanton = _CantonIns.ConsultarTodos();

                if (listaCanton.ToList().Count == 0)
                {
                    return NotFound();
                }
                return Ok(listaCanton);

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
    }
}
