using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class CategoriaProductoService : IService<TbCategoriaProducto>
    {
        IData<TbCategoriaProducto> _CategoriaProductoIns;

        public CategoriaProductoService(IData<TbCategoriaProducto> CategoriaProductoIns)
        {
            _CategoriaProductoIns = CategoriaProductoIns;
        }

        public bool Agregar(TbCategoriaProducto entity)
        {
            try
            {
               return _CategoriaProductoIns.Agregar(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TbCategoriaProducto ConsultarById(TbCategoriaProducto entity)
        {
            try
            {
                return _CategoriaProductoIns.ConsultarById(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TbCategoriaProducto> ConsultarTodos()
        {
            try
            {
                return _CategoriaProductoIns.ConsultarTodos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(TbCategoriaProducto entity)
        {
            try
            {
                return _CategoriaProductoIns.Eliminar(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Modificar(TbCategoriaProducto entity)
        {
            try
            {
                return _CategoriaProductoIns.Modificar(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
