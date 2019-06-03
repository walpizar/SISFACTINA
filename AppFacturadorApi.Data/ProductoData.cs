using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AppFacturadorApi.Data
{
    public class ProductoData : IData<TbProducto>
    {

        dbSISSODINAContext _Context;

        public ProductoData(dbSISSODINAContext Context)
        {
            _Context = Context;
        }

        public bool Agregar(TbProducto entity)
        {
            throw new NotImplementedException();
        }

        public TbProducto ConsultarById(TbProducto entity)
        {
            return _Context.TbProducto.Include("IdProductoNavigation").Where(x => x.IdProducto == entity.IdProducto).SingleOrDefault();
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
