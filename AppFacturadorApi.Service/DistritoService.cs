using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class DistritoService:IService<TbDistrito>
    {
        IData<TbDistrito> _DistritoIns;

        public DistritoService(IData<TbDistrito> DistritoIns)
        {
            _DistritoIns = DistritoIns;
        }

        public bool Agregar(TbDistrito entity)
        {
            throw new NotImplementedException();
        }

        public TbDistrito ConsultarById(TbDistrito entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbDistrito> ConsultarTodos()
        {
            try
            {
                return _DistritoIns.ConsultarTodos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(TbDistrito entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(TbDistrito entity)
        {
            throw new NotImplementedException();
        }
    }
}
