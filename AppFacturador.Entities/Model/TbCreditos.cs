using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Data
{
    public partial class TbCreditos
    {
        public TbCreditos()
        {
            TbAbonos = new HashSet<TbAbonos>();
        }

        public int IdCredito { get; set; }
        public string IdCliente { get; set; }
        public int? TipoCliente { get; set; }
        public int IdMov { get; set; }
        public bool IdEstado { get; set; }
        public bool EstadoCredito { get; set; }
        public decimal MontoCredito { get; set; }
        public DateTime FechaUltMod { get; set; }
        public DateTime FechaCrea { get; set; }
        public string UsuarioCrea { get; set; }
        public string UsuarioUltMod { get; set; }
        public decimal SaldoCredito { get; set; }

        public TbMovimientos IdMovNavigation { get; set; }
        public ICollection<TbAbonos> TbAbonos { get; set; }
    }
}
