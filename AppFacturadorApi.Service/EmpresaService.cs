using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class EmpresaService : IService<TbEmpresa>
    {
        IData<TbEmpresa> _empre;

        public EmpresaService(IData<TbEmpresa> empre)
        {
            _empre = empre;
        }

        public bool Agregar(TbEmpresa entity)
        {
            return _empre.Agregar(entity);
        }

        public TbEmpresa ConsultarById(TbEmpresa entity)
        {
            return _empre.ConsultarById(entity);
        }

        public IEnumerable<TbEmpresa> ConsultarTodos()
        {
            return _empre.ConsultarTodos();
        }

        public bool Eliminar(TbEmpresa entity)
        {
            return _empre.Eliminar(entity);
        }

        public bool Modificar(TbEmpresa entity)
        {
            return _empre.Modificar(entity);
        }
    }
}
