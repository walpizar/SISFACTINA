using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class TbCantonService:IService<TbCanton>
    {
        IData<TbCanton> _CantonIns;

        public TbCantonService(IData<TbCanton> CantonIns)
        {
            _CantonIns = CantonIns;
        }

        public bool Agregar(TbCanton entity)
        {
            throw new NotImplementedException();
        }

        public TbCanton ConsultarById(TbCanton entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbCanton> ConsultarTodos()
        {
            try
            {
                return _CantonIns.ConsultarTodos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(TbCanton entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(TbCanton entity)
        {
            throw new NotImplementedException();
        }
    }
}
