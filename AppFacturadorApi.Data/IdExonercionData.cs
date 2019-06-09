using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFacturadorApi.Data
{
    public class IdExonercionData : IData<TbExoneraciones>
    {
        dbSISSODINAContext _Contexto;

        public IdExonercionData(dbSISSODINAContext Contexto)
        {
            _Contexto = Contexto;
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
            return _Contexto.TbExoneraciones.ToList();
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
