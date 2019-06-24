using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFacturadorApi.Data
{
    public class IdExonercionData : IData<TbExoneraciones>
    {
        dbSISSODINAContext _Contexto;

        public IdExonercionData(dbSISSODINAContext Contexto)
        {
            _Contexto = Contexto;
        }

        public bool Agregar(TbExoneraciones entity)
        {
            try
            {
                _Contexto.TbExoneraciones.Add(entity);
                _Contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TbExoneraciones ConsultarById(TbExoneraciones entity)
        {
            try
            {
               return _Contexto.TbExoneraciones.Where(x => x.Id == entity.Id).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TbExoneraciones> ConsultarTodos()
        {
            return _Contexto.TbExoneraciones.ToList();
        }

        public bool Eliminar(TbExoneraciones entity)
        {
            try
            {
                _Contexto.Entry<TbExoneraciones>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _Contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Modificar(TbExoneraciones entity)
        {
            try
            {
                _Contexto.Entry<TbExoneraciones>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _Contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
