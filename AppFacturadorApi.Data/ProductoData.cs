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
        dbSISSODINAContext _context;

        public ProductoData(dbSISSODINAContext context)
        {
            _context = context;
        }

        public bool Agregar(TbProducto entity)
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

        public TbProducto ConsultarById(TbProducto entity)
        {
            try
            {
                return _context.TbProducto.Where(x => x.IdProducto == entity.IdProducto).Include("IdProductoNavigation").SingleOrDefault();
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
                return _context.TbProducto.Include("IdProductoNavigation").Include("IdTipoImpuestoNavigation").Include("IdCategoriaNavigation").Include("IdMedidaNavigation").Include("Id").ToList();

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
                if (entity.IdProductoNavigation != null)
                {
                    entity.IdProductoNavigation.Estado = false;
                    _context.Entry<TbInventario>(entity.IdProductoNavigation).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }

                entity.Estado = false;
                _context.Entry<TbProducto>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
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
                if (entity.IdProductoNavigation != null)
                {
                    _context.Entry<TbInventario>(entity.IdProductoNavigation).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }

                _context.Entry<TbProducto>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception EX)
            {

                throw;
            }
        }
    }
}
