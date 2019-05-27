using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AppFacturadorApi.Data
{
    public class TbPersonaData : IData<TbPersona>
    {
        dbSISSODINAContext _context;

        public TbPersonaData(dbSISSODINAContext context)
        {
            _context = context;
        }

        public bool Agregar(TbPersona entity)
        {
            try
            {
                _context.Entry<TbPersona>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TbPersona ConsultarById(TbPersona entity)
        {
            try
            {
                return (from per in _context.TbPersona where per.Identificacion == entity.Identificacion select per).SingleOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
       

        public IEnumerable<TbPersona> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(TbPersona entity)
        {
            try
            {
                _context.Entry<TbPersona>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Modificar(TbPersona entity)
        {
            try
            {
                _context.Entry<TbPersona>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
