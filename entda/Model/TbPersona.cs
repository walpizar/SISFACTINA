using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Entities.Model
{
    public partial class TbPersona
    {
        public TbPersona()
        {
            TbClientes = new HashSet<TbClientes>();
            TbEmpleado = new HashSet<TbEmpleado>();
            TbEmpresa = new HashSet<TbEmpresa>();
            TbProveedores = new HashSet<TbProveedores>();
        }

        public int TipoId { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime? FechaNac { get; set; }
        public int? Sexo { get; set; }
        public string CodigoPaisTel { get; set; }
        public int Telefono { get; set; }
        public string CodigoPaisFax { get; set; }
        public int? Fax { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string Barrio { get; set; }
        public string OtrasSenas { get; set; }

        public TbBarrios TbBarrios { get; set; }
        public TbTipoId Tipo { get; set; }
        public TbUsuarios TbUsuarios { get; set; }
        public ICollection<TbClientes> TbClientes { get; set; }
        public ICollection<TbEmpleado> TbEmpleado { get; set; }
        public ICollection<TbEmpresa> TbEmpresa { get; set; }
        public ICollection<TbProveedores> TbProveedores { get; set; }
    }
}
