using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Data
{
    public partial class TbTipoMovimiento
    {
        public TbTipoMovimiento()
        {
            TbMovimientos = new HashSet<TbMovimientos>();
        }

        public int IdTipo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public short AfectaConta { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioCrea { get; set; }
        public string UsuarioUltMod { get; set; }

        public ICollection<TbMovimientos> TbMovimientos { get; set; }
    }
}
