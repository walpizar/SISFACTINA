using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AppFacturadorApi.Data
{
    public class CategoriaProductoData : IData<TbCategoriaProducto>
    {
        dbSISSODINAContext _context;

        public CategoriaProductoData(dbSISSODINAContext context)
        {
            _context = context;
        }

        public bool Agregar(TbCategoriaProducto entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();
                return true;
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
                return _context.TbCategoriaProducto.Where(x => x.Id == entity.Id).SingleOrDefault();
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
                return _context.TbCategoriaProducto.Where(x=> x.Estado==true).ToList();
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
                entity.Estado = false;
                _context.Entry<TbCategoriaProducto>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
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
                _context.Entry<TbCategoriaProducto>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
