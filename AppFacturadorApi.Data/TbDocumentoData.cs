using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AppFacturadorApi.Data
{
    public class TbDocumentoData : IData<TbDocumento>
    {
        private dbSISSODINAContext _Context;

        public TbDocumentoData(dbSISSODINAContext Context)
        {
            _Context = Context;
        }

        public bool Agregar(TbDocumento entity)
        {
            try
            {
                _Context.Entry<TbDocumento>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public TbDocumento ConsultarById(TbDocumento entity)
        {
            try
            {
                return (from doc in _Context.TbDocumento where doc.Id == entity.Id select doc).SingleOrDefault();
            }
            catch (Exception)
            {

                throw ;
            }
        }

       

        public IEnumerable<TbDocumento> ConsultarTodos()
        {
            try
            {
                return (from doc in _Context.TbDocumento.Include("TbDetalleDocumento").Include("TipoPagoNavigation") select doc).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(TbDocumento entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(TbDocumento entity)
        {
            try
            {
                _Context.Entry<TbDocumento>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
