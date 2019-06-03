using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class ParametrosEmpresaService : IService<TbParametrosEmpresa>
    {
        IData<TbParametrosEmpresa> _empre;

        public ParametrosEmpresaService(IData<TbParametrosEmpresa> empre)
        {
            _empre = empre;
        }

        public bool Agregar(TbParametrosEmpresa entity)
        {
            return _empre.Agregar(entity);
        }

        public TbParametrosEmpresa ConsultarById(TbParametrosEmpresa entity)
        {
            return _empre.ConsultarById(entity);
        }

        public IEnumerable<TbParametrosEmpresa> ConsultarTodos()
        {
            return _empre.ConsultarTodos();
        }

        public bool Eliminar(TbParametrosEmpresa entity)
        {
            return _empre.Eliminar(entity);
        }

        public bool Modificar(TbParametrosEmpresa entity)
        {
            return _empre.Modificar(entity);
        }
    }
}
