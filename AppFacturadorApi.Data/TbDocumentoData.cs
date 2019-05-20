﻿using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AppFacturadorApi.Data
{
    public class TbDocumentoData : IData<TbDocumento>
    {
        private dbSISSODINAContext _Context;

        public TbDocumentoData(dbSISSODINAContext Context)
        {
            _Context = Context;
        }

        public bool Agregar(TbDocumento entity)
        {
            try
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
                    entity.TipoDocumento = 3;
                    _Context.TbDocumento.Add(entity);
                    _Context.SaveChanges();
                    return true;
                }

                return false;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public TbDocumento ConsultarById(TbDocumento entity)
        {
            try
            {
                return (from doc in _Context.TbDocumento where doc.Id == entity.Id select doc).SingleOrDefault();
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
                return (from doc in _Context.TbDocumento.Include("TbDetalleDocumento") select doc).ToList();
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
