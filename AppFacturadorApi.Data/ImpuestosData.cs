using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AppFacturadorApi.Data
{
    public class ImpuestosData : IData<TbImpuestos>
    {
        dbSISSODINAContext _Contexto;

        public ImpuestosData(dbSISSODINAContext Contexto)
        {
            _Contexto = Contexto;
        }

        public bool Agregar(TbImpuestos entity)
        {
            try
            {
                _Contexto.Entry<TbImpuestos>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                _Contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TbImpuestos ConsultarById(TbImpuestos entity)
        {
            try
            {
                return _Contexto.TbImpuestos.Where(x => x.Id == entity.Id).SingleOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public IEnumerable<TbImpuestos> ConsultarTodos()
        {
            return _Contexto.TbImpuestos.Where(x => x.Estado == true).ToList();
        }

        public bool Eliminar(TbImpuestos entity)
        {
            _Contexto.Entry<TbImpuestos>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _Contexto.SaveChanges();
            return true;
        }

        public bool Modificar(TbImpuestos entity)
        {
            _Contexto.Entry<TbImpuestos>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _Contexto.SaveChanges();
            return true;
        }
    }
}
