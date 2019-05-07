using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Data
{
    public partial class TbEmpresa
    {
        public TbEmpresa()
        {
            TbDocumento = new HashSet<TbDocumento>();
            TbParametrosEmpresa = new HashSet<TbParametrosEmpresa>();
            TbReporteHacienda = new HashSet<TbReporteHacienda>();
            TbUsuarios = new HashSet<TbUsuarios>();
        }

        public string Id { get; set; }
        public int TipoId { get; set; }
        public string RazonSocial { get; set; }
        public string CertificadoInstalado { get; set; }
        public string RutaCertificado { get; set; }
        public int? Pin { get; set; }
        public string UsuarioApiHacienda { get; set; }
        public string ClaveApiHacienda { get; set; }
        public string NumeroResolucion { get; set; }
        public DateTime? FechaResolucio { get; set; }
        public string CorreoElectronicoEmpresa { get; set; }
        public string ContrasenaCorreo { get; set; }
        public string NombreComercial { get; set; }
        public string CuerpoCorreo { get; set; }
        public string SubjectCorreo { get; set; }
        public DateTime? FechaCaducidad { get; set; }
        public bool? AmbientePruebas { get; set; }
        public string RutaXmlcompras { get; set; }
        public bool? ImprimeDoc { get; set; }

        public TbPersona TbPersona { get; set; }
        public ICollection<TbDocumento> TbDocumento { get; set; }
        public ICollection<TbParametrosEmpresa> TbParametrosEmpresa { get; set; }
        public ICollection<TbReporteHacienda> TbReporteHacienda { get; set; }
        public ICollection<TbUsuarios> TbUsuarios { get; set; }
    }
}
