using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class PersonaTribunalService : IService<TbPersonasTribunalS>
    {
        IData<TbPersonasTribunalS> _personaTri;

        public PersonaTribunalService(IData<TbPersonasTribunalS> personaTri)
        {
            _personaTri = personaTri;
        }

        public bool Agregar(TbPersonasTribunalS entity)
        {
            throw new NotImplementedException();
        }

        public TbPersonasTribunalS ConsultarById(TbPersonasTribunalS entity)
        {
            return _personaTri.ConsultarById(entity);
        }

        public IEnumerable<TbPersonasTribunalS> ConsultarTodos()
        {
            return _personaTri.ConsultarTodos();
        }

        public bool Eliminar(TbPersonasTribunalS entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(TbPersonasTribunalS entity)
        {
            throw new NotImplementedException();
        }
    }
}
