using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Data
{
    public partial class TbImpuestos
    {
        public TbImpuestos()
        {
            TbProducto = new HashSet<TbProducto>();
        }

        public int Id { get; set; }
        public decimal? Valor { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCrea { get; set; }
        public string UsuarioCrea { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioUltMod { get; set; }

        public ICollection<TbProducto> TbProducto { get; set; }
    }
}
