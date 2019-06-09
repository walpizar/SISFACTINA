using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class TipoClientesService : IService<TbTipoClientes>
    {
        IData<TbTipoClientes> _TipoClientes;

        public TipoClientesService(IData<TbTipoClientes> TipoClientes)
        {
            _TipoClientes = TipoClientes;
        }

        public bool Agregar(TbTipoClientes entity)
        {
            throw new NotImplementedException();
        }

        public TbTipoClientes ConsultarById(TbTipoClientes entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbTipoClientes> ConsultarTodos()
        {
            return _TipoClientes.ConsultarTodos();
        }

        public bool Eliminar(TbTipoClientes entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(TbTipoClientes entity)
        {
            throw new NotImplementedException();
        }
    }
}
