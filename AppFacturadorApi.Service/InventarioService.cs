using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class InventarioService : IService<TbInventario>
    {
        IData<TbInventario> _inv;

        public InventarioService(IData<TbInventario> inv)
        {
            _inv = inv;
        }

        public bool Agregar(TbInventario entity)
        {
            return _inv.Agregar(entity);
        }

        public TbInventario ConsultarById(TbInventario entity)
        {
            try
            {
                return _inv.ConsultarById(entity);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<TbInventario> ConsultarTodos()
        {
            return _inv.ConsultarTodos();
        }

        public bool Eliminar(TbInventario entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(TbInventario entity)
        {
            if (validarDatos(entity))
	        {
                return _inv.Modificar(entity);
	        }
            
        }
        private bool validarDatos(TbInventario inventario){
            if (inventario.IdProducto==null)
	        {
                return false;
	        }
            if (inventario.Cantidad==null)
	        {
                return false;
	        }
            if (inventario.Estado==null)
	        {
                return false;
	        }
            if (inventario.FechaCrea==null)
	        {
                return false;
	        }
            if (inventario.FechaUltMod==null)
	        {
                return false;
	        }
            if (inventario.IdProducto==null)
	        {
                return false;
	        }
            if (inventario.UsuarioCrea==null)
	        {
                return false;
	        }
            if (inventario.UsuarioUltMod==null)
	        {
                return false;
	        }
            return true;
        }
    }
}
