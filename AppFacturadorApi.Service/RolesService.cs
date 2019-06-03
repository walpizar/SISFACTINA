using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class RolesService : IService<TbRoles>
    {
        IData<TbRoles> _comb;

        public RolesService(IData<TbRoles> comb)
        {
            _comb = comb;
        }

        public bool Agregar(TbRoles entity)
        {
            throw new NotImplementedException();
        }

        public TbRoles ConsultarById(TbRoles entity)
        {
            return _comb.ConsultarById(entity);
        }

        public IEnumerable<TbRoles> ConsultarTodos()
        {
            return _comb.ConsultarTodos();
        }

        public bool Eliminar(TbRoles entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(TbRoles entity)
        {
            throw new NotImplementedException();
        }
    }
}
