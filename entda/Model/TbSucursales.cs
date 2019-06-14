using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Entities.Model
{
    public partial class TbSucursales
    {
        public TbSucursales()
        {
            TbCajas = new HashSet<TbCajas>();
        }
        public int Id { get; set; }
        public string IdEmpresa { get; set; }
        public int IdTipoEmpresa { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string Direccion { get; set; }
        public int? Telefono { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioCrea { get; set; }
        public string UsuarioUltMod { get; set; }

        public TbEmpresa IdNavigation { get; set; }
        public ICollection<TbCajas> TbCajas { get; set; }
    }
}
