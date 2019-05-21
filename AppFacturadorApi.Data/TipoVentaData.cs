using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace AppFacturadorApi.Data
{
    public class TipoVentaData : IData<TbTipoVenta>
    {
        dbSISSODINAContext _Contexto;

        public TipoVentaData(dbSISSODINAContext Contexto)
        {
            _Contexto = Contexto;
        }

        public bool Agregar(TbTipoVenta entity)
        {
            try
            {
                _Contexto.TbTipoVenta.Add(entity);
                _Contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TbTipoVenta ConsultarById(TbTipoVenta entity)
        {
            return _Contexto.TbTipoVenta.Where(x => x.Id == entity.Id).SingleOrDefault();
        }

        public IEnumerable<TbTipoVenta> ConsultarTodos()
        {
            return _Contexto.TbTipoVenta.ToList();
        }

        public bool Eliminar(TbTipoVenta entity)
        {
            _Contexto.Entry<TbTipoVenta>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _Contexto.SaveChanges();
            return true;
        }

        public bool Modificar(TbTipoVenta entity)
        {
            _Contexto.Entry<TbTipoVenta>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _Contexto.SaveChanges();
            return true;
        }
    }
}
