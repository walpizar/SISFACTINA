using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFacturadorApi.Controllers
{
    public class BarrioController:ControllerBase
    {
        IService<TbBarrios> _BarrioIns;

        public BarrioController(IService<TbBarrios> BarrioIns)
        {
            _BarrioIns = BarrioIns;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TbBarrios>> Get()
        {

            try
            {
                IEnumerable<TbBarrios> listaBarrio = _BarrioIns.ConsultarTodos();

                if (listaBarrio.ToList().Count == 0)
                {
                    return NotFound();
                }
                return Ok(listaBarrio);

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
    }
}
