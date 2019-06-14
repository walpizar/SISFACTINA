using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AppFacturadorApi.Data
{
    public class EmpresaData : IData<TbEmpresa>
    {
        dbSISSODINAContext _Contexto;

        public EmpresaData(dbSISSODINAContext Contexto)
        {
            _Contexto = Contexto;
        }

        public bool Agregar(TbEmpresa entity)
        {
            try
            {
                _Contexto.Entry<TbEmpresa>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                _Contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TbEmpresa ConsultarById(TbEmpresa entity)
        {
            try
            {
                
                return _Contexto.TbEmpresa.Include("TbParametrosEmpresa").Include("TbPersona").Where(x => x.Id.Trim() == entity.Id.Trim()).SingleOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public IEnumerable<TbEmpresa> ConsultarTodos()
        {
            return _Contexto.TbEmpresa.Include("TbParametrosEmpresa").Include("TbPersona").ToList();
        }

        public bool Eliminar(TbEmpresa entity)
        {
            try
            {
                _Contexto.Remove(entity);
                _Contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public bool Modificar(TbEmpresa entity)
        {
            try
            {


                //_Contexto.Entry<TbPersona>(entity.TbPersona).State = EntityState.Modified;
                _Contexto.Entry<TbEmpresa>(entity).State = EntityState.Modified;
               //_Contexto.Entry<TbParametrosEmpresa>(entity.TbParametrosEmpresa.First()).State = EntityState.Modified;
               
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
