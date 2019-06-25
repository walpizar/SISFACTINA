using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AppFacturadorApi.Data
{
    public class SucursalesData : IData<TbSucursales>
    {
        dbSISSODINAContext _Contexto;

        public SucursalesData(dbSISSODINAContext Contexto)
        {
            _Contexto = Contexto;
        }

        public bool Agregar(TbSucursales entity)
        {
            try
            {
                //Bandera
                bool bandera = false;
                //Esta validación es para saber cuando se puede ejecutar el _Contexto.SaveChanges
                if (entity.FechaUltMod == DateTime.MinValue)
                {
                    bandera = true;
                    entity.FechaUltMod = DateTime.Now;
                }

                _Contexto.TbSucursales.Add(entity);

                if (bandera)
                {
                    _Contexto.SaveChanges();
                }
                
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
            public TbSucursales ConsultarById(TbSucursales entity)
            {
            try
            {

                return _Contexto.TbSucursales.Where(x => x.IdEmpresa.Trim() == entity.IdEmpresa.Trim() && x.Id == entity.Id && x.IdTipoEmpresa == entity.IdTipoEmpresa).SingleOrDefault();
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TbSucursales> ConsultarTodos()
        {
            try
            {
                return _Contexto.TbSucursales.Include("TbDistrito.TbCanton").ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(TbSucursales entity)
        {
            try
            {
                _Contexto.TbSucursales.Remove(entity);
                _Contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Modificar(TbSucursales entity)
        {
            try
            {
                bool bandera = false;
                if (entity.FechaUltMod == DateTime.MinValue)
                {
                    bandera = true;
                }

                _Contexto.Entry<TbSucursales>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                if (bandera)
                {
                    entity.FechaUltMod = DateTime.Now;
                    _Contexto.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
