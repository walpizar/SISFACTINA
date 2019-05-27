using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFacturadorApi.Data
{
    public class TbDistritoData:IData<TbDistrito>
    {
        dbSISSODINAContext _context;

        public TbDistritoData(dbSISSODINAContext context)
        {
            _context = context;
        }

        public bool Agregar(TbDistrito entity)
        {
            throw new NotImplementedException();
        }

        public TbDistrito ConsultarById(TbDistrito entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbDistrito> ConsultarTodos()
        {
            try
            {
                return _context.TbDistrito.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(TbDistrito entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(TbDistrito entity)
        {
            throw new NotImplementedException();
        }
    }
}
