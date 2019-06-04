using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFacturadorApi.Data
{
    public class RolesData : IData<TbRoles>
    {
        dbSISSODINAContext _context;

        public RolesData(dbSISSODINAContext context)
        {
            _context = context;
        }

        public bool Agregar(TbRoles entity)
        {
            throw new NotImplementedException();
        }

        public TbRoles ConsultarById(TbRoles entity)
        {
            try
            {
               return _context.TbRoles.Where(x => x.IdRol == entity.IdRol).SingleOrDefault();
               
            }
            catch (Exception)
            {

                throw;
            }


        }

        public IEnumerable<TbRoles> ConsultarTodos()
        {
            try
            {
                return (from rol in _context.TbRoles select rol).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool Eliminar(TbRoles entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(TbRoles entity)
        {
            throw new NotImplementedException();
        }
    }
}
