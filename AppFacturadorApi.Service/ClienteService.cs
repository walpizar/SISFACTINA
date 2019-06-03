using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class ClientesService : IService<TbClientes>
    {
        IData<TbClientes> _client;

        public ClientesService(IData<TbClientes> client)
        {
            _client = client;
        }

        public bool Agregar(TbClientes entity)
        {
            return _client.Agregar(entity);
        }

        public TbClientes ConsultarById(TbClientes entity)
        {
            return _client.ConsultarById(entity);
        }

        public IEnumerable<TbClientes> ConsultarTodos()
        {
            return _client.ConsultarTodos();
        }

        public bool Eliminar(TbClientes entity)
        {
            return _client.Eliminar(entity);
        }

        public bool Modificar(TbClientes entity)
        {
            return _client.Modificar(entity);
        }
    }
}
