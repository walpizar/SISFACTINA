using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFacturadorApi.Data
{
    public class UsuarioData : IData<TbUsuarios>
    {
        dbSISSODINAContext _contex;

        public UsuarioData(dbSISSODINAContext contex)
        {
            _contex = contex;
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
            return _contex.TbUsuarios.ToList();
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
