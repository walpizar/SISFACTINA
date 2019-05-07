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

        public IEnumerable<TbAbonos> ConsultarTodos(string iddoc)
        {
            try
            {
                int id = int.Parse(iddoc);
                return (from abono in _context.TbAbonos where abono.IdDoc == id select abono).ToList();
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
