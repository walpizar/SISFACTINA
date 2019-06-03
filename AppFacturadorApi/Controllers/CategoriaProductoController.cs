using AppFacturadorApi.Entities.Model;
using AppFacturadorApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFacturadorApi.Controllers
{
    [Route("api/categoriaproducto")]
    [ApiController]
    public class CategoriaProductoController:ControllerBase
    {
        IService<TbCategoriaProducto> _CategoriaProducto;

        public CategoriaProductoController(IService<TbCategoriaProducto> CategoriaProducto)
        {
            _CategoriaProducto = CategoriaProducto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TbCategoriaProducto>> Get()
        {
            try
            {
                IEnumerable<TbCategoriaProducto> listaCatProduct = _CategoriaProducto.ConsultarTodos();

                if (listaCatProduct.ToList().Count == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(listaCatProduct);
                }
               
               
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<TbCategoriaProducto> Get(int id)
        {
            try
            {
                TbCategoriaProducto CategoriaProdu = null;
                CategoriaProdu.Id = id;
                CategoriaProdu = _CategoriaProducto.ConsultarById(CategoriaProdu);
                if (CategoriaProdu==null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(CategoriaProdu);
                }


            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpPost]
        public ActionResult<bool> Post([FromBody] TbCategoriaProducto CatProdut)
        {
            try
            {
               CatProdut.Estado = true;
               CatProdut.FechaCrea = DateTime.Now;
               CatProdut.FechaUltMod = DateTime.Now;
               CatProdut.UsuarioCrea = Environment.UserName;
               CatProdut.UsuarioUltMod = Environment.UserName;

                if (validaDatos(CatProdut))
                {
                    if (_CategoriaProducto.Agregar(CatProdut))
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
        public ActionResult<bool> Put([FromBody] TbCategoriaProducto CatProdut)
        {
            try
            {                
                CatProdut.FechaUltMod = DateTime.Now;                
                CatProdut.UsuarioUltMod = Environment.UserName;

                if (validaDatos(CatProdut))
                {
                    if (_CategoriaProducto.Modificar(CatProdut))
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
                TbCategoriaProducto CatProduct = new TbCategoriaProducto();
                CatProduct.Id = id;
                CatProduct = _CategoriaProducto.ConsultarById(CatProduct);
            
                if (validaDatos(CatProduct))
                {
                    if (_CategoriaProducto.Eliminar(CatProduct))
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



        private bool validaDatos(TbCategoriaProducto catProdut)
        {
            try
            {
                if (catProdut.Nombre==null)
                {
                    return false;
                }else if (catProdut.FechaCrea==null)
                {
                    return false;
                }else if (catProdut.FechaUltMod==null)
                {
                    return false;
                }else if (catProdut.UsuarioCrea==null)
                {
                    return false;
                }else if (catProdut.UsuarioUltMod==null)
                {
                    return true;
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
