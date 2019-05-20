using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AppFacturadorApi.Data
{
    public class TbProductoData : IData<TbProducto>
    {

        dbSISSODINAContext _Context;

        public TbProductoData(dbSISSODINAContext Context)
        {
            _Context = Context;
        }

        public bool Agregar(TbProducto entity)
        {
            throw new NotImplementedException();
        }

        public TbProducto ConsultarById(TbProducto entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbProducto> ConsultarTodos()
        {
            try
            {
                return _Context.TbProducto.ToList();
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
