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
    [Route("api/impuestos")]
    [ApiController]
    public class ImpuestosController : ControllerBase
    {
        IService<TbImpuestos> _impuest;

        public ImpuestosController(IService<TbImpuestos> impuest)
        {
            _impuest = impuest;
        }



        // GET: api/Empresa
        [HttpGet]
        public ActionResult<IEnumerable<TbImpuestos>> Get()
        {
            try
            {
                IEnumerable<TbImpuestos> listaImpuest = _impuest.ConsultarTodos();

                if (listaImpuest.ToList().Count == 0)
                {
                    return NotFound();
                }
                return Ok(listaImpuest);

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        // GET: api/Empresa/5
        [HttpGet("{id}")]
        public ActionResult<TbImpuestos> Get(int id)
        {
            try
            {
                TbImpuestos impuestos = new TbImpuestos();
                impuestos.Id = id;
                impuestos = _impuest.ConsultarById(impuestos);
                if (impuestos != null)
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

                return NotFound();
            }
        }

        // POST: api/Empresa
        [HttpPost]
        public ActionResult Post([FromBody] TbImpuestos impuestos)
        {
            try
            {
                impuestos.Estado = true;
                impuestos.FechaCrea = DateTime.Now;
                impuestos.UsuarioCrea = "walpizar";
                impuestos.FechaUltMod = DateTime.Now;
                impuestos.UsuarioUltMod = "walpizar";
                if (_impuest.Agregar(impuestos))
                {
                    return Ok(true);
                }
                else {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        // PUT: api/Empresa/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put([FromBody] TbImpuestos impuestos)
        {
            try
            {
                impuestos.FechaUltMod = DateTime.Now;
                impuestos.UsuarioUltMod = "walpizar";
                if (_impuest.Modificar(impuestos))
                {
                    return Ok(true);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(string id)
        {
            try
            {
                TbImpuestos impuestos = new TbImpuestos();
                impuestos.Id = int.Parse(id);
                impuestos = _impuest.ConsultarById(impuestos);
                impuestos.Estado = false;
                impuestos.FechaUltMod = DateTime.Now;
                impuestos.UsuarioUltMod = "walpizar";
                if (_impuest.Eliminar(impuestos))
                {
                    return Ok(true);
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
