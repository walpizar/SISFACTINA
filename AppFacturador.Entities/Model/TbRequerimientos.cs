using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Data
{
    public partial class TbRequerimientos
    {
        public TbRequerimientos()
        {
            TbPermisos = new HashSet<TbPermisos>();
        }

        public int IdReq { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioCrea { get; set; }
        public string UsuarioUltMod { get; set; }

        public ICollection<TbPermisos> TbPermisos { get; set; }
    }
}
