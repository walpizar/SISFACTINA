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

        public IEnumerable<TbDocumento> ConsultarTodos(string idCliente)
        {
            try
            {
                return _DocumentoIns.ConsultarTodos(idCliente);
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
    }
}
