using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class TipoIdService : IService<TbTipoId>
    {
            IData<TbTipoId> _Auto;

            public TipoIdService(IData<TbTipoId> Auto)
            {
                _Auto = Auto;
            }

            public bool Agregar(TbTipoId entity)
            {
                return _Auto.Agregar(entity);
            }

            public TbTipoId ConsultarById(TbTipoId entity)
            {
                return _Auto.ConsultarById(entity);
            }

            public IEnumerable<TbTipoId> ConsultarTodos()
            {
                return _Auto.ConsultarTodos();
            }

            public bool Eliminar(TbTipoId entity)
            {
                return _Auto.Eliminar(entity);
            }

            public bool Modificar(TbTipoId entity)
            {
                return _Auto.Modificar(entity);
            }
        }
    }
