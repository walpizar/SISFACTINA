using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AppFacturadorApi.Data
{
    public class TbPersonaData : IData<TbPersona>
    {
        dbSISSODINAContext _context;

        public TbPersonaData(dbSISSODINAContext context)
        {
            _context = context;
        }

        public bool Agregar(TbPersona entity)
        {
            throw new NotImplementedException();
        }

        public TbPersona ConsultarById(TbPersona entity)
        {
            try
            {
                return (from per in _context.TbPersona where per.Identificacion == entity.Identificacion select per).SingleOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
       

        public IEnumerable<TbPersona> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(TbPersona entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(TbPersona entity)
        {
            throw new NotImplementedException();
        }
    }
}
