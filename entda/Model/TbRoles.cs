using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Entities.Model
{
    public partial class TbRoles : IdentityRole<int>
    {
        public TbRoles()
        {
            TbPermisos = new HashSet<TbPermisos>();
            TbUsuarios = new HashSet<TbUsuarios>();
        }

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
