using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class TbDocumentoService : IService<TbDocumento>
    {
        IData<TbDocumento> _DocumentoIns;

        public TbDocumentoService(IData<TbDocumento> DocumentoIns)
        {
            _DocumentoIns = DocumentoIns;
        }

        public bool Agregar(TbDocumento entity)
        {
            try
            {
                if (validadCampos(entity) == false)
                {
                    return false;
                }

                return _DocumentoIns.Agregar(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TbDocumento ConsultarById(TbDocumento entity)
        {
            try
            {
                return _DocumentoIns.ConsultarById(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

       

        public IEnumerable<TbDocumento> ConsultarTodos()
        {
            try
            {
                return _DocumentoIns.ConsultarTodos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(TbDocumento entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(TbDocumento entity)
        {
            try
            {
                return _DocumentoIns.Modificar(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private bool validadCampos(TbDocumento fac)
        {
            if (fac.Id == 0)
            {
                return false;
            }

            if (fac.IdEmpresa == null)
            {
                return false;
            }
            if (fac.NotificarCorreo == null)
            {
                return false;
            }

            if (fac.TipoPago == null)
            {
                return false;
            }
            if (fac.TipoVenta == null)
            {
                return false;
            }

            if (fac.UsuarioCrea == null)
            {
                return false;
            }
            if (fac.UsuarioUltMod == null)
            {
                return false;
            }
            if (fac.ReporteElectronic == false)
            {
                return false;
            }
            if (fac.Fecha == null)
            {
                return false;
            }
            if (fac.FechaCrea == null)
            {
                return false;
            }
            if (fac.FechaRef == null)
            {
                return false;
            }
            if (fac.FechaUltMod == null)
            {
                return false;
            }
            if (fac.TipoDocumento == 0)
            {
                return false;
            }
            if (fac.EstadoFactura == 0)
            {
                return false;
            }
            if (fac.ReporteAceptaHacienda != false && fac.ReporteAceptaHacienda != true)
            {
                return false;
            }
            if (fac.Estado != true)
            {
                return false;
            }
            if (fac.TipoIdEmpresa == 0)
            {
                return false;
            }





            return true;
        }
    }
}
