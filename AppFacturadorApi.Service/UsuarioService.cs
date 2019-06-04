using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class UsuarioService : IService<TbUsuarios>
    {
        IData<TbUsuarios> _usuario;

        public UsuarioService(IData<TbUsuarios> usuario)
        {
            _usuario = usuario;
        }

        public bool Agregar(TbUsuarios entity)
        {
            throw new NotImplementedException();
        }

        public TbUsuarios ConsultarById(TbUsuarios entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbUsuarios> ConsultarTodos()
        {
            return _usuario.ConsultarTodos();
        }

        public bool Eliminar(TbUsuarios entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(TbUsuarios entity)
        {
            throw new NotImplementedException();
        }
    }
}
