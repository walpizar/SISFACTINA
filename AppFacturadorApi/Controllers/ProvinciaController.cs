using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFacturadorApi.Controllers
{
    [Route("api/provincia")]
    [ApiController]
    public class ProvinciaController:ControllerBase
    {

        IService<TbProvincia> _ProvinciaIns;

        public ProvinciaController(IService<TbProvincia> ProvinciaIns)
        {
            _ProvinciaIns = ProvinciaIns;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TbProvincia>> Get()
        {


            try
            {
                IEnumerable<TbProvincia> listaProvincia = _ProvinciaIns.ConsultarTodos();

                if (listaProvincia.ToList().Count == 0)
                {
                    return NotFound();
                }
                return Ok(listaProvincia);

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
    }
}
