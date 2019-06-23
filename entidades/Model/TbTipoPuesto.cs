using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Entities.Model
{
    public partial class TbTipoPuesto
    {
        public TbTipoPuesto()
        {
            TbEmpleado = new HashSet<TbEmpleado>();
        }

        public int IdTipoPuesto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double? PrecioHora { get; set; }
        public double? PrecioExt { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioCrea { get; set; }
        public string UsuarioUltMod { get; set; }

        public ICollection<TbEmpleado> TbEmpleado { get; set; }
    }
}
