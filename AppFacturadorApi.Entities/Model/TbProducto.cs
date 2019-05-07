using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Entities.Model
{
    public partial class TbProducto
    {
        public TbProducto()
        {
            TbDetalleDocumento = new HashSet<TbDetalleDocumento>();
        }

        public string IdProducto { get; set; }
        public string Nombre { get; set; }
        public int IdCategoria { get; set; }
        public string IdProveedor { get; set; }
        public int IdMedida { get; set; }
        public int? IdTipoIdProveedor { get; set; }
        public bool? PrecioVariable { get; set; }
        public decimal? PrecioUtilidad1 { get; set; }
        public decimal? PrecioUtilidad2 { get; set; }
        public decimal? PrecioUtilidad3 { get; set; }
        public decimal PrecioVenta1 { get; set; }
        public decimal PrecioVenta2 { get; set; }
        public decimal PrecioVenta3 { get; set; }
        public decimal Utilidad1Porc { get; set; }
        public decimal Utilidad3Porc { get; set; }
        public decimal Utilidad2Porc { get; set; }
        public decimal PrecioReal { get; set; }
        public bool EsExento { get; set; }
        public int IdTipoImpuesto { get; set; }
        public bool? AplicaDescuento { get; set; }
        public string Foto { get; set; }
        public decimal? DescuentoMax { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioCrea { get; set; }
        public string UsuarioUltMod { get; set; }

        public TbProveedores Id { get; set; }
        public TbCategoriaProducto IdCategoriaNavigation { get; set; }
        public TbTipoMedidas IdMedidaNavigation { get; set; }
        public TbInventario IdProductoNavigation { get; set; }
        public TbImpuestos IdTipoImpuestoNavigation { get; set; }
        public ICollection<TbDetalleDocumento> TbDetalleDocumento { get; set; }
    }
}
