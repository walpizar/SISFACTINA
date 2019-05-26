using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFacturadorApi.Data
{
    public class TbCantonData:IData<TbCanton>
    {
        dbSISSODINAContext _context;

        public TbCantonData(dbSISSODINAContext context)
        {
            _context = context;
        }

        public bool Agregar(TbCanton entity)
        {
            throw new NotImplementedException();
        }

        public TbCanton ConsultarById(TbCanton entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbCanton> ConsultarTodos()
        {
            try
            {
                return _context.TbCanton.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(TbCanton entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(TbCanton entity)
        {
            throw new NotImplementedException();
        }
    }
}
