using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AppFacturadorApi.Data
{
    public class TbProveedorData : IData<TbProveedores>
    {
        dbSISSODINAContext _context;
        IData<TbPersona> _PersonaIns;

        public TbProveedorData(dbSISSODINAContext context, IData<TbPersona> PersonaIns)
        {
            _context = context;
            _PersonaIns = PersonaIns;
        }

        public bool Agregar(TbProveedores entity)
        {
            try
            {
                TbPersona persona = _PersonaIns.ConsultarById(entity.TbPersona);
                if (persona==null)
                {
                    _context.TbProveedores.Add(entity);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    _context.Entry<TbPersona>(entity.TbPersona).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    entity.TbPersona = null;
                    _context.TbProveedores.Add(entity);
                    _context.SaveChanges();
                    return true;
                }
               
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public TbProveedores ConsultarById(TbProveedores entity)
        {
            try
            {
                return (from proveedor in _context.TbProveedores.Include("TbPersona.Tipo") where proveedor.Id == entity.Id && proveedor.TipoId==entity.TipoId select proveedor).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TbProveedores> ConsultarTodos()
        {
            try
            {
                return _context.TbProveedores.Include("TbPersona.Tipo").ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(TbProveedores entity)
        {
            try
            {
                _context.Entry<TbProveedores>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Modificar(TbProveedores entity)
        {
            try
            {
                _context.Entry<TbProveedores>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
