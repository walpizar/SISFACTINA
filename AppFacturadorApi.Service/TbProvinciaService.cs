using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class TbProvinciaService:IService<TbProvincia>
    {
        IData<TbProvincia> _ProvinciaIns;

        public TbProvinciaService(IData<TbProvincia> ProvinciaIns)
        {
            _ProvinciaIns = ProvinciaIns;
        }

        public bool Agregar(TbProvincia entity)
        {
            throw new NotImplementedException();
        }

        public TbProvincia ConsultarById(TbProvincia entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbProvincia> ConsultarTodos()
        {
            try
            {
                return _ProvinciaIns.ConsultarTodos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(TbProvincia entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(TbProvincia entity)
        {
            throw new NotImplementedException();
        }
    }
}
