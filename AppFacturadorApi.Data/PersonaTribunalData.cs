using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFacturadorApi.Data
{
    public class PersonaTribunalData : IData<TbPersonasTribunalS>
    {
        dbSISSODINAContext _context;

        public PersonaTribunalData(dbSISSODINAContext context)
        {
            _context = context;
        }

        public bool Agregar(TbPersonasTribunalS entity)
        {
            throw new NotImplementedException();
        }

        public TbPersonasTribunalS ConsultarById(TbPersonasTribunalS entity)
        {
            try
            {
                return _context.TbPersonasTribunalS.Where(x => x.Id == entity.Id).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TbPersonasTribunalS> ConsultarTodos()
        {
            try
            {
                return _context.TbPersonasTribunalS.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool Eliminar(TbPersonasTribunalS entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(TbPersonasTribunalS entity)
        {
            throw new NotImplementedException();
        }
    }
}
