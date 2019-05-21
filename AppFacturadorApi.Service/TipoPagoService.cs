using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class TipoPagoService : IService<TbTipoPago>
    {
        IData<TbTipoPago> _Pago;
        public TipoPagoService(IData<TbTipoPago> Pago)
        {
            _Pago = Pago;
        }

        public bool Agregar(TbTipoPago entity)
        {
            throw new NotImplementedException();
        }

        public TbTipoPago ConsultarById(TbTipoPago entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbTipoPago> ConsultarTodos()
        {
            return _Pago.ConsultarTodos();
        }

        public bool Eliminar(TbTipoPago entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(TbTipoPago entity)
        {
            throw new NotImplementedException();
        }
    }
}
