using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class ImpuestosService : IService<TbImpuestos>
    {
        IData<TbImpuestos> _impuest;

        public ImpuestosService(IData<TbImpuestos> impuest)
        {
            _impuest = impuest;
        }

        public bool Agregar(TbImpuestos entity)
        {
            return _impuest.Agregar(entity);
        }

        public TbImpuestos ConsultarById(TbImpuestos entity)
        {
            return _impuest.ConsultarById(entity);
        }

        public IEnumerable<TbImpuestos> ConsultarTodos()
        {
            return _impuest.ConsultarTodos();
        }

        public bool Eliminar(TbImpuestos entity)
        {
            return _impuest.Eliminar(entity);
        }

        public bool Modificar(TbImpuestos entity)
        {
            return _impuest.Modificar(entity);
        }
    }
}
