using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class ProductoService : IService<TbProducto>
    {
        IData<TbProducto> _contextPro;

        public ProductoService(IData<TbProducto> contextPro)
        {
            _contextPro = contextPro;
        }

        public bool Agregar(TbProducto entity)
        {
            try
            {
                return _contextPro.Agregar(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TbProducto ConsultarById(TbProducto entity)
        {
            try
            {
                return _contextPro.ConsultarById(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TbProducto> ConsultarTodos()
        {
            try
            {
                return _contextPro.ConsultarTodos();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool Eliminar(TbProducto entity)
        {
            try
            {
                return _contextPro.Eliminar(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Modificar(TbProducto entity)
        {
            try
            {
                return _contextPro.Modificar(entity);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
