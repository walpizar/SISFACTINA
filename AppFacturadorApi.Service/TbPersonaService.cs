using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class TbPersonaService : IService<TbPersona>
    {
        IData<TbPersona> _PersonaIns;

        public TbPersonaService(IData<TbPersona> PersonaIns)
        {
            _PersonaIns = PersonaIns;
        }

        public bool Agregar(TbPersona entity)
        {
            throw new NotImplementedException();
        }

        public TbPersona ConsultarById(TbPersona entity)
        {
            try
            {
                return _PersonaIns.ConsultarById(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TbPersona> ConsultarTodos(string idCliente)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(TbPersona entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(TbPersona entity)
        {
            throw new NotImplementedException();
        }
    }
}
