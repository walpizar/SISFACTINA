using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class RolesService : IService<TbRoles>
    {
        IData<TbRoles> _rol;

        public RolesService(IData<TbRoles> rol)
        {
            _rol = rol;
        }

        public bool Agregar(TbRoles entity)
        {
            throw new NotImplementedException();
        }

        public TbRoles ConsultarById(TbRoles entity)
        {
            return _rol.ConsultarById(entity);
        }

        public IEnumerable<TbRoles> ConsultarTodos()
        {
            return _rol.ConsultarTodos();
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
