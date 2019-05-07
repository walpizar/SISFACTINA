using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Data
{
    public partial class TbMovimientos
    {
        public TbMovimientos()
        {
            TbCreditos = new HashSet<TbCreditos>();
            TbDetalleMovimiento = new HashSet<TbDetalleMovimiento>();
            TbMovimientoCajaUsuario = new HashSet<TbMovimientoCajaUsuario>();
            TbPagos = new HashSet<TbPagos>();
        }

        public int IdMovimiento { get; set; }
        public DateTime Fecha { get; set; }
        public int IdTipoMov { get; set; }
        public bool Estado { get; set; }
        public string Motivo { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaUltMod { get; set; }
        public DateTime FechaCrea { get; set; }
        public string UsuarioCrea { get; set; }
        public string UsuarioUltMod { get; set; }

        public TbTipoMovimiento IdTipoMovNavigation { get; set; }
        public ICollection<TbCreditos> TbCreditos { get; set; }
        public ICollection<TbDetalleMovimiento> TbDetalleMovimiento { get; set; }
        public ICollection<TbMovimientoCajaUsuario> TbMovimientoCajaUsuario { get; set; }
        public ICollection<TbPagos> TbPagos { get; set; }
    }
}
