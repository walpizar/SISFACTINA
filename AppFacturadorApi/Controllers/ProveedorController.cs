using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFacturadorApi.Controllers
{

    [Route("api/proveedor")]
    [ApiController]
    public class ProveedorController:ControllerBase
    {
        IService<TbProveedores> _ProveedorIns;

        public ProveedorController(IService<TbProveedores> ProveedorIns)
        {
            _ProveedorIns = ProveedorIns;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TbProveedores>> Get()
        {

            try
            {
                IEnumerable<TbProveedores>  listaProveedores =  _ProveedorIns.ConsultarTodos();

                if ( listaProveedores.ToList().Count == 0)
                {
                    return NotFound();
                }
                foreach (var item in listaProveedores)
                {
                    item.TbPersona.Provincia.Trim();
                    item.TbPersona.Distrito.Trim();
                    item.TbPersona.Canton.Trim();
                    item.TbPersona.Barrio.Trim();
                }
                return Ok( listaProveedores);

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpGet("{id}/{TipoId}")]
        public ActionResult<TbProveedores> Get(string id,int tipoid)
        {

           
            try
            {
                TbProveedores proveedor = null;
                proveedor.Id = id;
                proveedor.TipoId=tipoid;
                proveedor = _ProveedorIns.ConsultarById(proveedor);


                if ( proveedor==null)
                {
                    return NotFound();
                }
                return Ok(proveedor);

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] TbProveedores proveedor)
        {
           

            try
            {
                proveedor.Id = proveedor.TbPersona.Identificacion;
                proveedor.TipoId = proveedor.TbPersona.TipoId;
                TbProveedores prove;
                prove = _ProveedorIns.ConsultarById(proveedor);
                if (prove==null)
                {
                    proveedor.Estado = true;                    
                    proveedor.FechaCrea = DateTime.Now;
                    proveedor.FechaUltMod = DateTime.Now;
                    proveedor.UsuarioCrea = Environment.UserName;
                    proveedor.UsuarioUltMod = Environment.UserName;

                    bool valido = validarcampos(proveedor);
                    if (valido)
                    {
                        bool agrego = _ProveedorIns.Agregar(proveedor);
                        if (agrego != true)
                        {
                            return NotFound("Error al agregar ");

                        }
                        return Ok("Se agrego Correctamente");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return NotFound("Ya existe proveedor con ese nombre");
                }
               

            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }

        private bool validarcampos(TbProveedores proveedor)
        {
            if (proveedor.Id==null)
            {
                return false;
            }
            else if (proveedor.TipoId==0)
            {
                return false;
            }
            else if (proveedor.ContactoProveedor== null)
            {
                return false;
            }
            else if (proveedor.FechaCrea == null)
            {
                return false;
            }
            else if (proveedor.FechaUltMod == null)
            {
                return false;
            }
            else if (proveedor.TbPersona.Identificacion == null)
            {
                return false;
            }
            else if(proveedor.TbPersona.TipoId==0)
            {
                return false;
            }
            else if (proveedor.TbPersona.CodigoPaisTel == null)
            {
                return false;
            }
            else if (proveedor.TbPersona.Telefono == 0)
            {
                return false;
            }
            else 
            {
                return true;
            }

        }

        [HttpPut]
        public ActionResult Put([FromBody] TbProveedores proveedor)
        {
            try
            {

                bool valido = validarcampos(proveedor);
                if (valido)
                {
                    proveedor.UsuarioUltMod = Environment.UserName;
                    proveedor.FechaUltMod = DateTime.Now;
                    bool modifico =  _ProveedorIns.Modificar(proveedor);
                    if (modifico != true)
                    {
                        return NotFound("Error al modificar");
                    }

                    return Ok("Se modifico correctamente");
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
        [HttpDelete("{id}/{TipoId}")]
        public ActionResult Delete(string id,int tipoid)
        {
            try
            {
                TbProveedores proveedor = new TbProveedores();
                proveedor.Id = id;
                proveedor.TipoId = tipoid;               
                proveedor = _ProveedorIns.ConsultarById(proveedor);
                proveedor.Estado = false;
                bool elimino = _ProveedorIns.Eliminar(proveedor);
                if (elimino)
                {
                    return Ok("Se elimino correctamente");
                }
                else
                {
                    return NotFound("Error al eliminar");
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }

    }
}
