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
    [Route("api/parametrosEmpresa")]
    [ApiController]
    public class ParametrosEmpresaController : ControllerBase
    {

        IService<TbParametrosEmpresa> _parEmpre;

        public ParametrosEmpresaController(IService<TbParametrosEmpresa> parEmpre)
        {
            _parEmpre = parEmpre;
        }



        // GET: api/Empresa
        [HttpGet]
        public ActionResult<IEnumerable<TbParametrosEmpresa>> Get()
        {
            try
            {
                IEnumerable<TbParametrosEmpresa> listaEmpre = _parEmpre.ConsultarTodos();

                if (listaEmpre.ToList().Count == 0)
                {
                    return NotFound();
                }
                return Ok(listaEmpre);

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<TbParametrosEmpresa> Get(string id)
        {
            try
            {
                TbParametrosEmpresa parametrosEmpresa = new TbParametrosEmpresa();
                parametrosEmpresa.IdEmpresa = id;
                parametrosEmpresa = _parEmpre.ConsultarById(parametrosEmpresa);
                if (parametrosEmpresa != null)
                {
                    return Ok(parametrosEmpresa);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        // POST: api/Empresa
        [HttpPost]
        public ActionResult Post([FromBody] TbParametrosEmpresa parametrosEmpresa)
        {
            try
            {
                return Ok(true);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        // PUT: api/Empresa/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put([FromBody] TbParametrosEmpresa parametrosEmpresa)
        {
            try
            {
                return Ok(true);
                
            }
            catch (Exception ex)
            {

                return StatusCode(500);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(String id)
        {
            try
            {
                return Ok(true);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
