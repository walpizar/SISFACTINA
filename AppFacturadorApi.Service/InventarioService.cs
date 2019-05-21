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
            throw new NotImplementedException();
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
            return _inv.Modificar(entity);
        }
    }
}
