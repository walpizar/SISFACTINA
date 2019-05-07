using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Data
{
    public partial class TbReporteHacienda
    {
        public int Id { get; set; }
        public string ConsecutivoReceptor { get; set; }
        public string ClaveReceptor { get; set; }
        public string ClaveDocEmisor { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaEmision { get; set; }
        public int TipoIdEmisor { get; set; }
        public string IdEmisor { get; set; }
        public string NombreEmisor { get; set; }
        public string EstadoRespHacienda { get; set; }
        public bool ReporteAceptaHacienda { get; set; }
        public string MensajeReporteHacienda { get; set; }
        public bool MensajeRespHacienda { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioCrea { get; set; }
        public string UsuarioUltMod { get; set; }
        public int EstadoRecibido { get; set; }
        public string Razon { get; set; }
        public decimal TotalImp { get; set; }
        public decimal TotalFactura { get; set; }
        public string IdEmpresa { get; set; }
        public int TipoIdEmpresa { get; set; }
        public string NombreArchivo { get; set; }
        public string RutaRespuestaHacienda { get; set; }
        public string XmlSinFirma { get; set; }
        public string XmlFirmado { get; set; }
        public string XmlRespuesta { get; set; }
        public string CorreoElectronico { get; set; }

        public TbEmpresa TbEmpresa { get; set; }
    }
}
