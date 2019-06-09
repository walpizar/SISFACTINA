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
            throw new NotImplementedException();
        }

        public TbExoneraciones ConsultarById(TbExoneraciones entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbExoneraciones> ConsultarTodos()
        {
            return _Context.ConsultarTodos();
        }

        public bool Eliminar(TbExoneraciones entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(TbExoneraciones entity)
        {
            throw new NotImplementedException();
        }
    }
}
