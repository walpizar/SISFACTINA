using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFacturadorApi.Data
{
    public class TipoClientesData : IData<TbTipoClientes>
    {
        dbSISSODINAContext _Contexto;

        public TipoClientesData(dbSISSODINAContext Contexto)
        {
            _Contexto = Contexto;
        }

        public bool Agregar(TbTipoClientes entity)
        {
            throw new NotImplementedException();
        }

        public TbTipoClientes ConsultarById(TbTipoClientes entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbTipoClientes> ConsultarTodos()
        {
            return _Contexto.TbTipoClientes.ToList();
        }

        public bool Eliminar(TbTipoClientes entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(TbTipoClientes entity)
        {
            throw new NotImplementedException();
        }
    }
}
