using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class TbAbonosService : IService<TbAbonos>
    {
        IData<TbAbonos> _context;

        public TbAbonosService(IData<TbAbonos> context)
        {
            _context = context;
        }

        public bool Agregar(TbAbonos entity)
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

        public TbAbonos ConsultarById(TbAbonos entity)
        {
            throw new NotImplementedException();
        }

        
        public IEnumerable<TbAbonos> ConsultarTodos()
        {
            try
            {
                return _context.ConsultarTodos();
            }
            catch (Exception)
            {

                throw;
            };
        }

        public bool Eliminar(TbAbonos entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(TbAbonos entity)
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
