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
    [Route("api/empresa")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {

        IService<TbEmpresa> _empre;
        IService<TbPersona> _perso;
        IService<TbParametrosEmpresa> _parEmpre;

        public EmpresaController(IService<TbEmpresa> empre, IService<TbPersona> perso, IService<TbParametrosEmpresa> parEmpre)
        {
            _empre = empre;
            _perso = perso;
            _parEmpre = parEmpre;
        }



        // GET: api/Empresa
        [HttpGet]
        public ActionResult <IEnumerable<TbEmpresa>> Get()
        {
            try
            {
                IEnumerable<TbEmpresa> listaEmpre = _empre.ConsultarTodos();

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

        // GET: api/Empresa/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Empresa
        [HttpPost]
        public ActionResult Post([FromBody] TbParametrosEmpresa ParEmpre)
        {
            try
            {
                ParEmpre.IdTipoEmpresa = 1;
                TbPersona persona = new TbPersona();
                persona = ParEmpre.IdNavigation.TbPersona;
                persona = _perso.ConsultarById(persona);
                if (persona != null)
                {
                    if (_empre.Agregar(ParEmpre.IdNavigation))
                    {
                        if (_parEmpre.Agregar(ParEmpre))
                        {
                            return Ok();
                        }
                        else
                        {
                            return NotFound();
                        }
                    }
                    else
                    {
                        return NotFound();
                    }

                }
                else {
                    if (_perso.Agregar(ParEmpre.IdNavigation.TbPersona))
                    {
                        if (_empre.Agregar(ParEmpre.IdNavigation))
                        {
                            if (_parEmpre.Agregar(ParEmpre))
                            {
                                return Ok();
                            }
                            else {
                                return NotFound();
                            }
                        }
                        else {
                            return NotFound();
                        }
                    }
                    else {
                        return NotFound();
                    }
                    
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        // PUT: api/Empresa/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<TbEmpresa> Delete(String id)
        {
            try
            {
                TbEmpresa empresa = new TbEmpresa();
                empresa.Id = id;
                empresa = _empre.ConsultarById(empresa);
                if (empresa != null)
                {
                    TbParametrosEmpresa parametros = new TbParametrosEmpresa();
                    parametros.IdEmpresa = empresa.Id;
                    parametros = _parEmpre.ConsultarById(parametros);
                    if (parametros != null)
                    {
                        if (_parEmpre.Eliminar(parametros))
                        {
                            if (_empre.Eliminar(empresa))
                            {
                                return Ok();
                            }
                            else
                            {
                                return NotFound();
                            }
                        }
                        else
                        {
                            return NotFound();
                        }
                    }
                    else
                    {
                        if (_empre.Eliminar(empresa))
                        {
                            return Ok();
                        }
                        else
                        {
                            return NotFound();
                        }
                    }
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
    }
}
