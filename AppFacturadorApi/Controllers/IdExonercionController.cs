using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppFacturadorApi.Controllers
{
    [Route("api/exoneraciones")]
    [ApiController]
    public class IdExonercionController : Controller
    {
        IService<TbExoneraciones> _ExoneracionesIns;

        public IdExonercionController(IService<TbExoneraciones> ExoneracionesIns)
        {
            _ExoneracionesIns = ExoneracionesIns;
        }


        [HttpGet]
        public ActionResult<IEnumerable<TbExoneraciones>> Get()
        {

            try
            {
                IEnumerable<TbExoneraciones> listaExonera = _ExoneracionesIns.ConsultarTodos();
                if (listaExonera != null)
                {
                    return Ok(listaExonera);

                }
                return BadRequest();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<TbExoneraciones>> Get(int id)
        {

            try
            {
                TbExoneraciones exoneracion = new TbExoneraciones();
                exoneracion.Id = id;
                exoneracion = _ExoneracionesIns.ConsultarById(exoneracion);
                if (exoneracion != null)
                {
                    return Ok(exoneracion);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<bool> Post([FromBody] TbExoneraciones exonerar)
        {
            try
            {
                TbExoneraciones exonera = _ExoneracionesIns.ConsultarById(exonerar);
                if (exonera==null)
                {
                    bool agregado = _ExoneracionesIns.Agregar(exonerar);
                    if (agregado)
                    {
                        return Ok();
                    }
                }
                return BadRequest();
            }
            catch (Exception)
            {

                return NotFound();
            }
        }



        [HttpPut]
        public ActionResult<bool> Put([FromBody] TbExoneraciones exonera)
        {
            try
            {
                TbExoneraciones exonera2 = _ExoneracionesIns.ConsultarById(exonera);
                exonera2.Nombre = exonera.Nombre;
                exonera2.Descripcion = exonera.Descripcion;
                exonera2.Valor = exonera.Valor;

                bool modificado = _ExoneracionesIns.Modificar(exonera2);

                if (modificado)
                {
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception)
            {

                return NotFound();
            }
        }//cierre metodo

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                //consulto para ver si realmente existe ese tipo de exoneracion
                TbExoneraciones exoneracion = new TbExoneraciones();
                exoneracion.Id = id;
                exoneracion = _ExoneracionesIns.ConsultarById(exoneracion);

                //si existe
                if (exoneracion!=null)
                {
                    //se manda a eliminar
                    bool eliminado = _ExoneracionesIns.Eliminar(exoneracion);
                    if (eliminado)//si se realizo correctamente
                    {
                        return Ok();
                    }
                }
                return BadRequest();
            }
            catch (Exception)
            {

                return NotFound();
            }
        }
    }
}


