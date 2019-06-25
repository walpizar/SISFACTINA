using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class SucursalesService : IService<TbSucursales>
    {
        IData<TbSucursales> _suc;

        public SucursalesService(IData<TbSucursales> suc)
        {
            _suc = suc;
        }

        public bool Agregar(TbSucursales entity)
        {
            if (validadCampos(entity))
            {
                return _suc.Agregar(entity);
            }
            return false;
        }

        public TbSucursales ConsultarById(TbSucursales entity)
        {
            try
            {
                return _suc.ConsultarById(entity);
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
                return _suc.ConsultarTodos();
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
                return _suc.Eliminar(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Modificar(TbSucursales entity)
        {
            
                return _suc.Modificar(entity);
	        
            
        }

        private bool validadCampos(TbSucursales suc)
        {
            if ( 0 < suc.Id )
            {
                return false;
            }
            if (suc.IdEmpresa == null)
            {
                return false;
            }
            if (suc.IdTipoEmpresa < 0 )
            {
                return false;
            }
            if (suc.Provincia ==null)
            {
                return false;
            }
            if (suc.Canton == null)
            {
                return false;
            }
            if (suc.Distrito == null)
            {
                return false;
            }
            if (suc.FechaCrea == null)
            {
                return false;
            }
            if (suc.FechaUltMod == null)
            {
                return false;
            }
            if (suc.UsuarioCrea == null)
            {
                return false;
            }
            if (suc.UsuarioUltMod == null)
            {
                return false;
            }
            return true;
        }
    }
}
