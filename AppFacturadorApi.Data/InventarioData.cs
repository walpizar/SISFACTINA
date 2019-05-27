using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AppFacturadorApi.Data
{
    public class InventarioData : IData<TbInventario>
    {
        dbSISSODINAContext _Contexto;

        public InventarioData(dbSISSODINAContext Contexto)
        {
            _Contexto = Contexto;
        }

        public bool Agregar(TbInventario entity)
        {
            throw new NotImplementedException();
        }

        public TbInventario ConsultarById(TbInventario entity)
        {
            try
            {

                return _Contexto.TbInventario.Where(x => x.IdProducto.Trim() == entity.IdProducto.Trim()).SingleOrDefault();
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TbInventario> ConsultarTodos()
        {
            try
            {
                return _Contexto.TbInventario.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(TbInventario entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(TbInventario entity)
        {
            try
            {
                bool bandera = false;
                if (entity.FechaUltMod == DateTime.MinValue)
                {
                    bandera = true;
                }

                _Contexto.Entry<TbInventario>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                if (bandera)
                {
                    entity.FechaUltMod = DateTime.Now;
                    _Contexto.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
