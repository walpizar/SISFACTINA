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

        TbClientes existe;

        public ClientesService(IData<TbClientes> client)
        {
            _client = client;
        }

        public bool Agregar(TbClientes entity)
        {
            try
            {
                return _client.Agregar(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TbClientes ConsultarById(TbClientes entity)
        {
            try
            {
                return _client.ConsultarById(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TbClientes> ConsultarTodos()
        {
            try
            {
                return _client.ConsultarTodos();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(TbClientes entity)
        {
            throw new NotImplementedException();
            //try
            //{
            //    return _client.Eliminar(entity);

            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        public bool Modificar(TbClientes entity)
        {
            throw new NotImplementedException();
            //try
            //{

            //    return _client.Modificar(entity);
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }
    }
}
