using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFacturadorApi.Controllers
{
    [Route("api/tipomedida")]
    [ApiController]
    public class TipoMedidaController:ControllerBase
    {

        IService<TbTipoMedidas> _InsTipoMedida;

        public TipoMedidaController(IService<TbTipoMedidas> InsTipoMedida)
        {
            _InsTipoMedida = InsTipoMedida;
        }


        [HttpGet]
        public ActionResult<IEnumerable<TbTipoMedidas>> Get()
        {
            try
            {
                IEnumerable<TbTipoMedidas> listaTipoMedida = _InsTipoMedida.ConsultarTodos();

                if (listaTipoMedida.ToList().Count == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(listaTipoMedida);
                }


            }
            catch (Exception ex)
            {

                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<TbTipoMedidas> Get(int id)
        {
            try
            {
                TbTipoMedidas tipomedida = null;
                tipomedida.IdTipoMedida = id;
                tipomedida = _InsTipoMedida.ConsultarById(tipomedida);
                if (tipomedida == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(tipomedida);
                }


            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpPost]
        public ActionResult<bool> Post([FromBody] TbTipoMedidas tipomedida)
        {
            try
            {
                tipomedida.Estado = true;
                tipomedida.FechaCrea = DateTime.Now;
                tipomedida.FechaUltMod = DateTime.Now;
                tipomedida.UsuarioCrea = Environment.UserName;
                tipomedida.UsuarioUltMod = Environment.UserName;

                if (validaDatos(tipomedida))
                {
                    if (_InsTipoMedida.Agregar(tipomedida))
                    {
                        return Ok(true);
                    }
                    else
                    {
                        return NotFound(false);
                    }
                }
                else
                {
                    return NotFound(false);
                }


            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpPut]
        public ActionResult<bool> Put([FromBody] TbTipoMedidas tipomedida)
        {
            try
            {
                tipomedida.FechaUltMod = DateTime.Now;
                tipomedida.UsuarioUltMod = Environment.UserName;

                if (validaDatos(tipomedida))
                {
                    if (_InsTipoMedida.Modificar(tipomedida))
                    {
                        return Ok(true);
                    }
                    else
                    {
                        return NotFound(false);
                    }
                }
                else
                {
                    return NotFound(false);
                }


            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                TbTipoMedidas tipomedida = new TbTipoMedidas();
                tipomedida.IdTipoMedida = id;
                tipomedida = _InsTipoMedida.ConsultarById(tipomedida);

                if (validaDatos(tipomedida))
                {
                    if (_InsTipoMedida.Eliminar(tipomedida))
                    {
                        return Ok(true);
                    }
                    else
                    {
                        return NotFound(false);
                    }
                }
                else
                {
                    return NotFound(false);
                }


            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }



        private bool validaDatos(TbTipoMedidas tipomedida)
        {
            try
            {
                if (tipomedida.Nombre == null)
                {
                    return false;
                }
                else if (tipomedida.Nomenclatura == null)
                {
                    return false;
                }
                else if (tipomedida.FechaCrea == null)
                {
                    return false;
                }
                else if (tipomedida.FechaUltMod == null)
                {
                    return false;
                }
                else if (tipomedida.UsuarioCrea == null)
                {
                    return false;
                }else if (tipomedida.UsuarioUltMod==null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
