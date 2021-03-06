﻿using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class DetalleDocumentoService : IService<TbDetalleDocumento>
    {
        IData<TbDetalleDocumento> _context;

        public DetalleDocumentoService(IData<TbDetalleDocumento> context)
        {
            _context = context;
        }

        public bool Agregar(TbDetalleDocumento entity)
        {
            try
            {
                return _context.Agregar(entity);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public TbDetalleDocumento ConsultarById(TbDetalleDocumento entity)
        {
            try
            {
                return _context.ConsultarById(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

       

        public IEnumerable<TbDetalleDocumento> ConsultarTodos()
        {
            try
            {
                return _context.ConsultarTodos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(TbDetalleDocumento entity)
        {
            try
            {
                return _context.Eliminar(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Modificar(TbDetalleDocumento entity)
        {
            try
            {
                return _context.Modificar(entity);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
