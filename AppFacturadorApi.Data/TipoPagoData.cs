using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AppFacturadorApi.Data
{
    public class TipoPagoData : IData<TbTipoPago>
    {
        dbSISSODINAContext _Contexto;

        public TipoPagoData(dbSISSODINAContext Contexto)
        {
            _Contexto = Contexto;
        }

        public bool Agregar(TbTipoPago entity)
        {
            try
            {
                _Contexto.TbTipoPago.Add(entity);
                _Contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TbTipoPago ConsultarById(TbTipoPago entity)
        {
            return _Contexto.TbTipoPago.Where(x => x.Id == entity.Id).SingleOrDefault();
        }

        public IEnumerable<TbTipoPago> ConsultarTodos()
        {
            return _Contexto.TbTipoPago.ToList();
        }

        public bool Eliminar(TbTipoPago entity)
        {
            _Contexto.Entry<TbTipoPago>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _Contexto.SaveChanges();
            return true;
        }

        public bool Modificar(TbTipoPago entity)
        {
            _Contexto.Entry<TbTipoPago>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _Contexto.SaveChanges();
            return true;
        }
    }
}
