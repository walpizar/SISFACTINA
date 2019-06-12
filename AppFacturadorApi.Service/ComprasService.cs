using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class ComprasService : IService<TbDocumento>
    {
        // var inyeccion de datos Data
        IService<TbDocumento> _Context;
        // constructor con inyeccion de datos
        public ComprasService(IService<TbDocumento> Context)
        {
            _Context = Context;
        }

        public bool Agregar(TbDocumento entity)
        {
            try
            {
                return _Context.Agregar(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TbDocumento ConsultarById(TbDocumento entity)
        {
            try
            {
                return _Context.ConsultarById(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TbDocumento> ConsultarTodos()
        {
            try
            {
                return _Context.ConsultarTodos();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(TbDocumento entity)
        {
            try
            {
                return _Context.Eliminar(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Modificar(TbDocumento entity)
        {
            return _Context.Modificar(entity);
        }
    }
}
