using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Entities.Model
{
    public partial class TbTipoIngrediente
    {
        public TbTipoIngrediente()
        {
            TbIngredientes = new HashSet<TbIngredientes>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioCrea { get; set; }
        public string UsuarioUltMod { get; set; }

        public ICollection<TbIngredientes> TbIngredientes { get; set; }
    }
}
