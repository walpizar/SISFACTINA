using AppFacturadorApi.Data.Model;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AppFacturadorApi.Data
{
    public class ClientesData : IData<TbClientes>
    {
        dbSISSODINAContext _Contexto;

        public ClientesData(dbSISSODINAContext Contexto)
        {
            _Contexto = Contexto;
        }

        public bool Agregar(TbClientes entity)
        {
            try
            {
                _Contexto.TbClientes.Add(entity);
                _Contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TbClientes ConsultarById(TbClientes entity)
        {
            try
            {
                return _Contexto.TbClientes.Include("TbPersona.TbBarrios.TbDistrito.TbCanton.ProvinciaNavigation").Include("IdExonercionNavigation").Where(x => x.Id.Trim() == entity.Id.Trim() && x.TipoId == entity.TipoId).SingleOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public IEnumerable<TbClientes> ConsultarTodos()
        {
            return _Contexto.TbClientes.Include("TbPersona").Include("TbPersona.TbBarrios").Where(x => x.Estado == true).ToList();
        }

        public bool Eliminar(TbClientes entity)
        {
            _Contexto.Entry<TbClientes>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _Contexto.SaveChanges();
            return true;
        }

        public bool Modificar(TbClientes entity)
        {
            entity.Estado = true;
            _Contexto.Entry<TbClientes>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _Contexto.SaveChanges();
            return true;
        }
    }
}
