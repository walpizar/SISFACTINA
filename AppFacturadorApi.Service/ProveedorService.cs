using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class TbProveedorService : IService<TbProveedores>
    {
        IData<TbProveedores> _ProveedoresIns;

        public TbProveedorService(IData<TbProveedores> ProveedoresIns)
        {
            _ProveedoresIns = ProveedoresIns;
        }

        public bool Agregar(TbProveedores entity)
        {
            try
            {              
               return _ProveedoresIns.Agregar(entity);               
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TbProveedores ConsultarById(TbProveedores entity)
        {
            try
            {
                return _ProveedoresIns.ConsultarById(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TbProveedores> ConsultarTodos()
        {
            try
            {
               return  _ProveedoresIns.ConsultarTodos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(TbProveedores entity)
        {
            try
            {
                return _ProveedoresIns.Eliminar(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Modificar(TbProveedores entity)
        {
            try
            {
                return _ProveedoresIns.Modificar(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
