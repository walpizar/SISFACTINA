using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFacturadorApi.Controllers
{
    [Route("api/tipoid")]
    [ApiController]
    public class TbTipoIdController : ControllerBase
    {
        IService<TbTipoId> _tpId;

        public TbTipoIdController(IService<TbTipoId> tpId)
        {
            _tpId = tpId;
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<TbTipoId>> Get()
        {
            try
            {
                IEnumerable<TbTipoId> ListaTbTipoIds;
                ListaTbTipoIds= _tpId.ConsultarTodos();
                if (ListaTbTipoIds.ToList().Count!=0)
                {
                    return Ok(ListaTbTipoIds);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<TbTipoId> Get(int id)
        {
            try
            {
                TbTipoId TbTipoId = new TbTipoId();
                TbTipoId.Id = id;
               
                TbTipoId = _tpId.ConsultarById(TbTipoId);
                if (TbTipoId != null)
                {
                    return Ok(TbTipoId);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }

        // POST api/values
        [HttpPost]
        public ActionResult<bool> Post([FromBody] TbTipoId TbTipoId)
        {
            
                try
                {
                    
                    if (_tpId.Agregar(TbTipoId) == true)
                    {
                        return Ok(true);
                    }
                    return NotFound();
                }
                catch (Exception)
                {

                    return StatusCode(500);
                }

            
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult<TbTipoId> Put([FromBody] TbTipoId TbTipoId)
        {
            try
            {

                if ( _tpId.Modificar(TbTipoId)== true)
                {
                    return Ok(true);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        // DELETE api/values/5/2
        [HttpDelete("{id}")]
        public ActionResult<TbTipoId> Delete(int id)
        {
            try
            {
                TbTipoId TbTipoId = new TbTipoId();
                TbTipoId.Id = id;
                TbTipoId = _tpId.ConsultarById(TbTipoId);
                if (_tpId.Eliminar(TbTipoId) == true)
                {
                    return Ok(true);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

    }
}
