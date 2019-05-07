using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Data
{
    public partial class TbCategoriaProducto
    {
        public TbCategoriaProducto()
        {
            TbProducto = new HashSet<TbProducto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Fotocategoria { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioCrea { get; set; }
        public string UsuarioUltMod { get; set; }

        public ICollection<TbProducto> TbProducto { get; set; }
    }
}
