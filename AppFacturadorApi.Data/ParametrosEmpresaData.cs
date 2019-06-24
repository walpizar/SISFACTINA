using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AppFacturadorApi.Data
{
    public class ParametrosEmpresaData : IData<TbParametrosEmpresa>
    {
        dbSISSODINAContext _Contexto;

        public ParametrosEmpresaData(dbSISSODINAContext Contexto)
        {
            _Contexto = Contexto;
        }

        public bool Agregar(TbParametrosEmpresa entity)
        {
            try
            {
                _Contexto.Entry<TbParametrosEmpresa>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                _Contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TbParametrosEmpresa ConsultarById(TbParametrosEmpresa entity)
        {
            try
            {

                return _Contexto.TbParametrosEmpresa.Where(x => x.IdEmpresa.Trim() == entity.IdEmpresa.Trim()).SingleOrDefault();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public IEnumerable<TbParametrosEmpresa> ConsultarTodos()
        {
            return _Contexto.TbParametrosEmpresa.ToList();
        }

        public bool Eliminar(TbParametrosEmpresa entity)
        {
            _Contexto.Remove(entity);
            _Contexto.SaveChanges();
            return true;
        }

        public bool Modificar(TbParametrosEmpresa entity)
        {

            try
            {
                _Contexto.Entry<TbParametrosEmpresa>(entity).State = EntityState.Detached;
                _Contexto.Entry<TbParametrosEmpresa>(entity).State = EntityState.Deleted;
                _Contexto.Entry<TbParametrosEmpresa>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                _Contexto.SaveChanges();
                return true;
            }
            catch (Exception EX)
            {

                return false;
            }
        }
    }
}
