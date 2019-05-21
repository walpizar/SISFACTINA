using AppFacturadorApi.Data;
using AppFacturadorApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFacturadorApi.Service
{
    public class TbDocumentoService : IService<TbDocumento>
    {
        IData<TbDocumento> _DocumentoIns;
        IService<TbEmpresa> _EmpresaIns;
        IService<TbInventario> _InventarioIns;

        public TbDocumentoService(IData<TbDocumento> DocumentoIns, IService<TbEmpresa> EmpresaIns, IService<TbInventario> InventarioIns)
        {
            _DocumentoIns = DocumentoIns;
            _EmpresaIns = EmpresaIns;
            _InventarioIns = InventarioIns;
        }

        public bool Agregar(TbDocumento entity)
        {
            try
            {
                IEnumerable<TbInventario> ListaInventario = _InventarioIns.ConsultarTodos();

                
                TbEmpresa empresa = new TbEmpresa();
                empresa.Id= entity.IdEmpresa;
                empresa =_EmpresaIns.ConsultarById(empresa);

                
                if (validadCampos(entity) == false || empresa == null)
                {
                   return false;
                }

                for (int i = 0; i < entity.TbDetalleDocumento.ToList().Count; i++)
                {
                    TbInventario inventario = new TbInventario();
                    inventario = ListaInventario.Where(x => x.IdProducto.Trim() == entity.TbDetalleDocumento.ToList()[i].IdProducto).SingleOrDefault();
                    if (inventario.Cantidad >= entity.TbDetalleDocumento.ToList()[i].Cantidad)
                    {
                        if (empresa.TbParametrosEmpresa.Where(x => x.IdEmpresa == empresa.Id).SingleOrDefault().ManejaInventario == true)
                        {

                            if (entity.TipoDocumento == 1)
                            {
                                inventario.Cantidad -= entity.TbDetalleDocumento.ToList()[i].Cantidad;
                                _InventarioIns.Modificar(inventario);
                            }
                            else if (entity.TipoDocumento==3)
                            {

                            }   

                        }
                        
                    }
                    else
                    {
                        return false;
                    }

                }

                return _DocumentoIns.Agregar(entity);
            
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TbDocumento ConsultarById(TbDocumento entity)
        {
            try
            {
                return _DocumentoIns.ConsultarById(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

       

        public IEnumerable<TbDocumento> ConsultarTodos()
        {
            try
            {
                return _DocumentoIns.ConsultarTodos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(TbDocumento entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(TbDocumento entity)
        {
            try
            {
                return _DocumentoIns.Modificar(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private bool validadCampos(TbDocumento fac)
        {
            if (fac.Id == 0)
            {
                return false;
            }

            if (fac.IdEmpresa == null)
            {
                return false;
            }
            if (fac.NotificarCorreo == null)
            {
                return false;
            }

            if (fac.TipoPago == null)
            {
                return false;
            }
            if (fac.TipoVenta == null)
            {
                return false;
            }

            if (fac.UsuarioCrea == null)
            {
                return false;
            }
            if (fac.UsuarioUltMod == null)
            {
                return false;
            }
            
            if (fac.Fecha == null)
            {
                return false;
            }
            if (fac.FechaCrea == null)
            {
                return false;
            }
            if (fac.FechaRef == null)
            {
                return false;
            }
            if (fac.FechaUltMod == null)
            {
                return false;
            }
            if (fac.TipoDocumento == 0)
            {
                return false;
            }
            if (fac.EstadoFactura == 0)
            {
                return false;
            }
            if (fac.ReporteAceptaHacienda != false && fac.ReporteAceptaHacienda != true)
            {
                return false;
            }
            if (fac.Estado != true)
            {
                return false;
            }
            if (fac.TipoIdEmpresa == 0)
            {
                return false;
            }

            return true;
        }
    }
}
