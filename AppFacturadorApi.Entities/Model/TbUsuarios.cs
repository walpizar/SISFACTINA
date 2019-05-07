using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Entities.Model
{
    public partial class TbUsuarios
    {
        public TbUsuarios()
        {
            TbCajaUsuario = new HashSet<TbCajaUsuario>();
        }

        public int TipoId { get; set; }
        public string Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public int IdRol { get; set; }
        public string FotoUrl { get; set; }
        public string IdEmpresa { get; set; }
        public int? IdTipoIdEmpresa { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioCrea { get; set; }
        public string UsuarioUltMod { get; set; }

        public TbEmpresa IdNavigation { get; set; }
        public TbRoles IdRolNavigation { get; set; }
        public TbPersona TbPersona { get; set; }
        public ICollection<TbCajaUsuario> TbCajaUsuario { get; set; }
    }
}
