using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Entities.Model
{
    public partial class TbIngredientes
    {
        public TbIngredientes()
        {
            TbDetalleMovimiento = new HashSet<TbDetalleMovimiento>();
            TbDetalleProducto = new HashSet<TbDetalleProducto>();
            TbIngredienteProveedor = new HashSet<TbIngredienteProveedor>();
        }

        public int IdIngrediente { get; set; }
        public string Nombre { get; set; }
        public int IdTipoMedida { get; set; }
        public int IdTipoIngrediente { get; set; }
        public decimal PrecioCompra { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioCrea { get; set; }
        public string UsuarioUltMod { get; set; }

        public TbTipoIngrediente IdTipoIngredienteNavigation { get; set; }
        public ICollection<TbDetalleMovimiento> TbDetalleMovimiento { get; set; }
        public ICollection<TbDetalleProducto> TbDetalleProducto { get; set; }
        public ICollection<TbIngredienteProveedor> TbIngredienteProveedor { get; set; }
    }
}
