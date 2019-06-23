using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Entities.Model
{
    public partial class TbRoles
    {
        public TbRoles()
        {
            TbPermisos = new HashSet<TbPermisos>();
            TbUsuarios = new HashSet<TbUsuarios>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioCrea { get; set; }
        public string UsuarioUltMod { get; set; }

        public ICollection<TbPermisos> TbPermisos { get; set; }
        public ICollection<TbUsuarios> TbUsuarios { get; set; }
    }
}
