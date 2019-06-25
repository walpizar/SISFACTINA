using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.FacturaElectronica.ClasesDatos;
using AppFacturadorApi.Service;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFacturadorApi.Controllers
{
    [Route("api/sucursales")]
    [ApiController]
    public class SucursalController : ControllerBase
    {
        IService<TbSucursales> _SucursalesIns;
        IService<TbInventario> _inv;

        Datos Datos;

        public SucursalController(IService<TbSucursales> SucursalesIns, IService<TbInventario> inv, Datos datos)
        {
            _SucursalesIns = SucursalesIns;
            _inv = inv;
            Datos = datos;
        }

        string sucursal = "001";
        string caja = "01";
        string codigoPais = "506";


        // GET api/values

        [HttpGet("{id}/{tipoId}")]
        public ActionResult<IEnumerable<TbSucursales>> Get(string id, int tipoId)
        {

            try
            {

                //Metodo sin finalizar

                IEnumerable<TbSucursales> listaSucursales = _SucursalesIns.ConsultarTodos();
                listaSucursales = listaSucursales.Where(x => x.IdEmpresa.Trim() == id.Trim() && x.IdTipoEmpresa == tipoId);
                if (listaSucursales != null)
                {
                    return Ok(listaSucursales);

                }
                return BadRequest();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        //GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<TbSucursales> Get(int id)
        {
            try
            {

                //Metodo sin finalizar


                TbSucursales Documento = new TbSucursales();
                Documento.Id = id;
                Documento = _SucursalesIns.ConsultarById(Documento);
                if (Documento == null)
                {
                    return NotFound("No se encontro ningun Documento");
                }


                return Ok(Documento);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }

        // POST api/values
        [HttpPost]
        public ActionResult<bool> Post([FromBody] IEnumerable<TbSucursales> sucursales)
        {
            try
            {
                //Metodo sin finalizar
                bool bandera = true;

                for (int i = 0; i < sucursales.ToList().Count; i++)
                {
                    sucursales.ToList()[i].FechaCrea = DateTime.Now;
                    sucursales.ToList()[i].FechaUltMod = DateTime.Now;
                    if (i==sucursales.ToList().Count-1)
                    {
                        sucursales.ToList()[i].FechaUltMod = DateTime.MinValue;
                    }
                    bool aux = _SucursalesIns.Agregar(sucursales.ToList()[i]);
                    if (aux == false)
                    {
                        bandera = false;
                        break;
                    }

                }
                if (bandera == true)
                {
                    return Ok(bandera);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {

                return NotFound();
            }
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult<bool> Put([FromBody] TbSucursales Doc)
        {
            try
            {

                //Metodo sin finalizar

                bool modifico = _SucursalesIns.Modificar(Doc);

                if (modifico)
                {
                    return Ok(true);
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

        // DELETE api/values/5
        [HttpDelete("{id}/{tipoId}/{idEmpresa}")]
        public ActionResult Delete(int id, int tipoId, string idEmpresa)
        {
            try
            {
                TbSucursales suc = new TbSucursales();

                suc.Id = id;
                suc.IdTipoEmpresa = tipoId;
                suc.IdEmpresa = idEmpresa;

                suc = _SucursalesIns.ConsultarById(suc);

                if (_SucursalesIns.Eliminar(suc))
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

                return StatusCode(500);
            }

        }
    }
}
