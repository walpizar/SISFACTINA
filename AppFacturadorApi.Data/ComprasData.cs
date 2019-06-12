using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFacturadorApi.Data
{
    public class ComprasData : IData<TbDocumento>
    {
        // var inyeccion de datos
        dbSISSODINAContext _Contexto;
        // constructor con inyeccion de dtos
        public ComprasData(dbSISSODINAContext Contexto)
        {
            _Contexto = Contexto;
        }

        public bool Agregar(TbDocumento entity)
        {
            try
            {
                _Contexto.TbDocumento.Add(entity);
                _Contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TbDocumento ConsultarById(TbDocumento entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbDocumento> ConsultarTodos()
        {
            try
            {
                return _Contexto.TbDocumento.Include("TbDetalleDocumento").Where(x => x.Estado == true && x.TipoDocRef == 6).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Eliminar(TbDocumento entity)
        {
            try
            {
                entity.Estado = false;
                _Contexto.Entry<TbDocumento>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _Contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Modificar(TbDocumento entity)
        {
            try
            {
                entity.Estado = true;
                _Contexto.Entry<TbDocumento>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _Contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
