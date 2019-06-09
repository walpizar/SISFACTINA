using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class TipoMedidaService : IService<TbTipoMedidas>
    {
        IData<TbTipoMedidas> _InsTipoMedida;

        public TipoMedidaService(IData<TbTipoMedidas> InsTipoMedida)
        {
            _InsTipoMedida = InsTipoMedida;
        }

        public bool Agregar(TbTipoMedidas entity)
        {
            try
            {
                return _InsTipoMedida.Agregar(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TbTipoMedidas ConsultarById(TbTipoMedidas entity)
        {
            try
            {
                return _InsTipoMedida.ConsultarById(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TbTipoMedidas> ConsultarTodos()
        {
            try
            {
                return _InsTipoMedida.ConsultarTodos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(TbTipoMedidas entity)
        {
            try
            {
                return _InsTipoMedida.Eliminar(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Modificar(TbTipoMedidas entity)
        {
            try
            {
                return _InsTipoMedida.Modificar(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
