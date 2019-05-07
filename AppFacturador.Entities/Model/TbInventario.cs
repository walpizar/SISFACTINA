using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Data
{
    public partial class TbInventario
    {
        public string IdProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal? CantMin { get; set; }
        public decimal? CantMax { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioCrea { get; set; }
        public string UsuarioUltMod { get; set; }

        public TbProducto TbProducto { get; set; }
    }
}
