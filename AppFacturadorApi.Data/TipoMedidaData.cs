using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AppFacturadorApi.Data
{
    public class TipoMedidaData : IData<TbTipoMedidas>
    {

        private dbSISSODINAContext _Context;

        public TipoMedidaData(dbSISSODINAContext Context)
        {
            _Context = Context;
        }

        public bool Agregar(TbTipoMedidas entity)
        {
            try
            {
                _Context.Add(entity);
                _Context.SaveChanges();
                return true;
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
                return _Context.TbTipoMedidas.Where(x => x.IdTipoMedida == entity.IdTipoMedida).SingleOrDefault();
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
                return _Context.TbTipoMedidas.Where(x => x.Estado == true).ToList();
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
                entity.Estado = false;
                _Context.Entry<TbTipoMedidas>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _Context.SaveChanges();
                return true;
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
                _Context.Entry<TbTipoMedidas>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
