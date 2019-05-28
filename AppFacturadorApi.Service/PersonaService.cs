using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class PersonaService : IService<TbPersona>
    {
        IData<TbPersona> _PersonaIns;

        public PersonaService(IData<TbPersona> PersonaIns)
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

        public IEnumerable<TbPersona> ConsultarTodos()
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
