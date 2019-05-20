using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFacturadorApi.Controllers
{

    [Route("api/abonos")]
    [ApiController]
    public class AbonosController : ControllerBase
    {
        IService<TbAbonos> _AbonosIns;

        public AbonosController(IService<TbAbonos> AbonosIns)
        {
            _AbonosIns = AbonosIns;
        }
        [HttpGet]
        public ActionResult<IEnumerable<TbAbonos>> Get()
        {


            try
            {
                IEnumerable<TbAbonos> listaAbonos = _AbonosIns.ConsultarTodos();

                if (listaAbonos.ToList().Count == 0)
                {
                    return NotFound();
                }
                return Ok(listaAbonos);

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<TbAbonos>> Get(int id)
        {

            string IdDoc = id.ToString();
            try
            {
                IEnumerable<TbAbonos> listaAbonos = _AbonosIns.ConsultarTodos();
                listaAbonos = listaAbonos.Where(x => x.IdDoc == id).ToList();
                if (listaAbonos.ToList().Count == 0)
                {
                    return NotFound();
                }
                return Ok(listaAbonos);

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] TbAbonos Abono)
        {
            Abono.FechaCrea = DateTime.Now;
            Abono.FechaUltMod = DateTime.Now;
            try
            {
                bool valido = validarcampos(Abono);
                if (valido)
                {
                    bool agrego = _AbonosIns.Agregar(Abono);
                    if (agrego != true)
                    {
                        return NotFound();

                    }
                    return Ok("Se agrego Correctamente");
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

        private bool validarcampos(TbAbonos abono)
        {
            if (abono.IdDoc == 0)
            {
                return false;
            }
            else if (abono.TipoDoc == 0)
            {
                return false;
            }
            else if (abono.UsuarioCrea == null)
            {
                return false;
            }
            else if (abono.UsuarioUltMod == null)
            {
                return false;
            }
            else if (abono.FechaCrea == null)
            {
                return false;
            }
            else if (abono.FechaUltMod == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] TbAbonos Abono)
        {
            try
            {
                bool valido = validarcampos(Abono);
                if (valido)
                {
                    bool modifico = _AbonosIns.Modificar(Abono);
                    if (modifico != true)
                    {
                        return NotFound();
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
    }
}
