using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AppFacturadorApi.Data
{
    public class TipoIdData : IData<TbTipoId>
    {
        dbSISSODINAContext _Contexto;

        public TipoIdData(dbSISSODINAContext Contexto)
        {
            _Contexto = Contexto;
        }

        public bool Agregar(TbTipoId entity)
        {
            try
            {
                _Contexto.TbTipoId.Add(entity);
                _Contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TbTipoId ConsultarById(TbTipoId entity)
        {

            return _Contexto.TbTipoId.Where(x => x.Id == entity.Id).SingleOrDefault();
        }

        public IEnumerable<TbTipoId> ConsultarTodos()
        {
            return _Contexto.TbTipoId.ToList();
        }

        public bool Eliminar(TbTipoId entity)
        {
            _Contexto.TbTipoId.Remove(entity);
            _Contexto.SaveChanges();
            return true;
        }

        public bool Modificar(TbTipoId entity)
        {
            _Contexto.Entry<TbTipoId>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _Contexto.SaveChanges();
            return true;
        }
    }
}
