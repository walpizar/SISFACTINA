using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFacturadorApi.Data
{
    public class ProvinciaData:IData<TbProvincia>
    {
        dbSISSODINAContext _context;

        public ProvinciaData(dbSISSODINAContext context)
        {
            _context = context;
        }

        public bool Agregar(TbProvincia entity)
        {
            throw new NotImplementedException();
        }

        public TbProvincia ConsultarById(TbProvincia entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbProvincia> ConsultarTodos()
        {
            try
            {
                return _context.TbProvincia.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(TbProvincia entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(TbProvincia entity)
        {
            throw new NotImplementedException();
        }
    }
}
