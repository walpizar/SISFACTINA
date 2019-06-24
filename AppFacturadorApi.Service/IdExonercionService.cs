using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class IdExonercionService : IService<TbExoneraciones>
    {
        IData<TbExoneraciones> _Context;

        public IdExonercionService(IData<TbExoneraciones> Context)
        {
            _Context = Context;
        }

        public bool Agregar(TbExoneraciones entity)
        {
           return _Context.Agregar(entity);
        }

        public TbExoneraciones ConsultarById(TbExoneraciones entity)
        {
            return _Context.ConsultarById(entity);
        }

        public IEnumerable<TbExoneraciones> ConsultarTodos()
        {
            return _Context.ConsultarTodos();
        }

        public bool Eliminar(TbExoneraciones entity)
        {
            return _Context.Eliminar(entity);
        }

        public bool Modificar(TbExoneraciones entity)
        {
            return _Context.Modificar(entity);
        }
    }
}
