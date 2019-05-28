using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class ProductoService : IService<TbProducto>
    {
        IData<TbProducto> _ProduIns;

        public ProductoService(IData<TbProducto> ProduIns)
        {
            _ProduIns = ProduIns;
        }

        public bool Agregar(TbProducto entity)
        {
            throw new NotImplementedException();
        }

        public TbProducto ConsultarById(TbProducto entity)
        {
            return _ProduIns.ConsultarById(entity);
        }

        public IEnumerable<TbProducto> ConsultarTodos()
        {

            try
            {
                return _ProduIns.ConsultarTodos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(TbProducto entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(TbProducto entity)
        {
            throw new NotImplementedException();
        }
    }
}
