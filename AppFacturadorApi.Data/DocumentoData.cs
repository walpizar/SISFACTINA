using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AppFacturadorApi.Data
{
    public class DocumentoData : IData<TbDocumento>
    {
        private dbSISSODINAContext _Context;
        IData<TbInventario> _inven;

        public DocumentoData(dbSISSODINAContext Context, IData<TbInventario> inven)
        {
            _Context = Context;
            _inven = inven;
        }

        public bool Agregar(TbDocumento entity)
        {
            try
            {

                //guarda un nuevo documento
                if (entity.TipoDocumento == 1 || entity.TipoDocumento == 6)
                {
                    _Context.TbDocumento.Add(entity);
                    _Context.SaveChanges();
                    return true;
                }

                //crea la nota de credito
                else if (entity.TipoDocumento == 3)
                {

                    TbDocumento documentoAnt = new TbDocumento();
                    documentoAnt.Id = entity.Id;

                    documentoAnt = _Context.TbDocumento.Where(x => x.Id == documentoAnt.Id).SingleOrDefault();
                    if (documentoAnt != null)
                    {
                        documentoAnt.FechaUltMod = DateTime.Now;
                        documentoAnt.UsuarioUltMod = Environment.UserName;

                        documentoAnt.Estado = false;
                        _Context.Entry<TbDocumento>(documentoAnt).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                        var idMax = (from c in _Context.TbDocumento select c.Id).Max();
                        entity.Id = idMax + 1;

                        _Context.TbDocumento.Add(entity);
                        _Context.SaveChanges();

                        return true;
                    }
                } 

                return false;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public TbDocumento ConsultarById(TbDocumento entity)
        {
            try
            {
                return (from doc in _Context.TbDocumento.Include("TbDetalleDocumento") where doc.Id == entity.Id select doc).SingleOrDefault();
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
                
                return _Context.TbDocumento.Include("TbDetalleDocumento").Include("TbClientes.TbPersona").Where(x => x.Estado == true).ToList();

            }
            catch (Exception ex)
            {

                throw ex;
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
                _Context.Entry<TbDocumento>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
