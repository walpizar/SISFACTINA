using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFacturadorApi.Data
{
    public class TbAbonosData : IData<TbAbonos>
    {
        dbSISSODINAContext _context;

        public TbAbonosData(dbSISSODINAContext context)
        {
            _context = context;
        }

        public bool Agregar(TbAbonos entity)
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

        public TbAbonos ConsultarById(TbAbonos entity)
        {
            throw new NotImplementedException();
        }

      

        public IEnumerable<TbAbonos> ConsultarTodos()
        {
            try
            {
                return _context.TbAbonos.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(TbAbonos entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(TbAbonos entity)
        {
            try
            {
               _context.Entry<TbAbonos>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
