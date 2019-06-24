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

        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
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
