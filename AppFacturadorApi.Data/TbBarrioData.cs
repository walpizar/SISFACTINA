using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFacturadorApi.Data
{
    public class TbBarrioData:IData<TbBarrios>
    {
        dbSISSODINAContext _context;

        public TbBarrioData(dbSISSODINAContext context)
        {
            _context = context;
        }

        public bool Agregar(TbBarrios entity)
        {
            throw new NotImplementedException();
        }

        public TbBarrios ConsultarById(TbBarrios entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbBarrios> ConsultarTodos()
        {
            try
            {
                return _context.TbBarrios.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(TbBarrios entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(TbBarrios entity)
        {
            throw new NotImplementedException();
        }
    }
}
