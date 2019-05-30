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
        public ActionResult<IEnumerable<TbEmpresa>> Get()
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
        public ActionResult<TbEmpresa> Get(string id)
        {
            try
            {
                TbEmpresa empresa = new TbEmpresa();
                empresa.Id = id;
                empresa = _empre.ConsultarById(empresa);
                if (empresa != null)
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
        public ActionResult Post([FromBody] TbEmpresa empresa)
        {
            try
            {
                TbEmpresa tbEmpresa = new TbEmpresa();
                tbEmpresa = empresa;
                TbParametrosEmpresa parametrosEmpresa = new TbParametrosEmpresa();
                parametrosEmpresa = empresa.TbParametrosEmpresa.ToList().SingleOrDefault();
                TbPersona persona = new TbPersona();
                persona = _perso.ConsultarById(empresa.TbPersona);
                if (persona != null)
                {
                    tbEmpresa = _empre.ConsultarById(empresa);
                    if (tbEmpresa == null)
                    {

                        if (_empre.Agregar(empresa))
                        {
                            if (_parEmpre.Agregar(parametrosEmpresa))
                            {
                                return Ok(true);
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
                        parametrosEmpresa = _parEmpre.ConsultarById(parametrosEmpresa);
                        if (parametrosEmpresa == null)
                        {
                            if (_parEmpre.Agregar(parametrosEmpresa))
                            {
                                return Ok(true);
                            }
                            else {

                                return NotFound();

                            }
                        }
                        else
                        {
                            return NotFound();
                        }
                    }

                }
                else {
                    if (_perso.Agregar(empresa.TbPersona))
                    {
                        if (_empre.Agregar(empresa))
                        {
                            if (_parEmpre.Agregar(parametrosEmpresa))
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
        public ActionResult<bool> Put([FromBody] TbEmpresa empresa)
        {
            try
            {
                TbParametrosEmpresa parametrosEmpresa = new TbParametrosEmpresa();
                parametrosEmpresa = empresa.TbParametrosEmpresa.ToList().SingleOrDefault();
                if (_empre.Modificar(empresa))
                {
                    parametrosEmpresa =  _parEmpre.ConsultarById(parametrosEmpresa);
                    if (_parEmpre.Modificar(parametrosEmpresa))
                    {
                        return Ok(true);
                    }
                    else
                    {
                        return NotFound();
                    }
                    //return Ok(true);
                }
                else {
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
        public ActionResult<bool> Delete(String id)
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
                                return Ok(true);
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
                            return Ok(true);
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
