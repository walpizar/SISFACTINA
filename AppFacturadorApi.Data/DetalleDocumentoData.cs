using AppFacturadorApi.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AppFacturadorApi.Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace AppFacturadorApi.Data
{
    public class DetalleDocumentoData : IData<TbDetalleDocumento>
    {
        dbSISSODINAContext _context;

        public DetalleDocumentoData(dbSISSODINAContext context)
        {
            _context = context;
        }

        public bool Agregar(TbDetalleDocumento entity)
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

        public TbDetalleDocumento ConsultarById(TbDetalleDocumento entity)
        {
            try
            {
                return (from detalle in _context.TbDetalleDocumento where detalle.Id == entity.Id select detalle).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }

        }
      

        public IEnumerable<TbDetalleDocumento> ConsultarTodos()
        {
            try
            {
                return _context.TbDetalleDocumento.Include("IdProductoNavigation").ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Eliminar(TbDetalleDocumento entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(TbDetalleDocumento entity)
        {
            try
            {
                _context.Entry<TbDetalleDocumento>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
