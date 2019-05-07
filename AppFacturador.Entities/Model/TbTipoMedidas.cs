using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Data
{
    public partial class TbTipoMedidas
    {
        public TbTipoMedidas()
        {
            TbProducto = new HashSet<TbProducto>();
        }

        public int IdTipoMedida { get; set; }
        public string Nombre { get; set; }
        public string Nomenclatura { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioCrea { get; set; }
        public string UsuarioUltMod { get; set; }

        public ICollection<TbProducto> TbProducto { get; set; }
    }
}
