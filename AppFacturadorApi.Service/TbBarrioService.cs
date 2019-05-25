using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class TbBarrioService : IService<TbBarrios>
    {
        IData<TbBarrios> _BarrioIns;

        public TbBarrioService(IData<TbBarrios> BarrioIns)
        {
            _BarrioIns = BarrioIns;
        }

        public bool Agregar(TbBarrios entity)
        {
            throw new NotImplementedException();
        }

        public TbBarrios ConsultarById(TbBarrios entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbBarrios> ConsultarTodos()
        {
            try
            {
                return _BarrioIns.ConsultarTodos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(TbBarrios entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(TbBarrios entity)
        {
            throw new NotImplementedException();
        }
    }
}
