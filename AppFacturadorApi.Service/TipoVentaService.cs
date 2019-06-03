using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class TipoVentaService : IService<TbTipoVenta>
    {
        IData<TbTipoVenta> _venta;

        public TipoVentaService(IData<TbTipoVenta> Auto)
        {
            _venta = Auto;
        }

        public bool Agregar(TbTipoVenta entity)
        {
            return _venta.Agregar(entity);
        }

        public TbTipoVenta ConsultarById(TbTipoVenta entity)
        {
            return _venta.ConsultarById(entity);
        }

        public IEnumerable<TbTipoVenta> ConsultarTodos()
        {
            return _venta.ConsultarTodos();
        }

        public bool Eliminar(TbTipoVenta entity)
        {
            return _venta.Eliminar(entity);
        }

        public bool Modificar(TbTipoVenta entity)
        {
            return _venta.Modificar(entity);
        }
    }
}
