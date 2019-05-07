using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Entities.Model
{
    public partial class TbDocumento
    {
        public TbDocumento()
        {
            TbDetalleDocumento = new HashSet<TbDetalleDocumento>();
        }

        public int Id { get; set; }
        public int TipoDocumento { get; set; }
        public string Consecutivo { get; set; }
        public string Clave { get; set; }
        public bool ReporteElectronic { get; set; }
        public DateTime Fecha { get; set; }
        public string IdCliente { get; set; }
        public int? TipoIdCliente { get; set; }
        public int? TipoVenta { get; set; }
        public int? Plazo { get; set; }
        public int? TipoPago { get; set; }
        public string RefPago { get; set; }
        public int? TipoMoneda { get; set; }
        public decimal? TipoCambio { get; set; }
        public int EstadoFactura { get; set; }
        public string EstadoFacturaHacienda { get; set; }
        public bool ReporteAceptaHacienda { get; set; }
        public string MensajeReporteHacienda { get; set; }
        public bool? MensajeRespHacienda { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioCrea { get; set; }
        public string UsuarioUltMod { get; set; }
        public bool Estado { get; set; }
        public bool NotificarCorreo { get; set; }
        public string Correo1 { get; set; }
        public string Correo2 { get; set; }
        public string Observaciones { get; set; }
        public string IdEmpresa { get; set; }
        public int TipoIdEmpresa { get; set; }
        public int? TipoDocRef { get; set; }
        public string ClaveRef { get; set; }
        public DateTime? FechaRef { get; set; }
        public int? CodigoRef { get; set; }
        public string Razon { get; set; }
        public string XmlSinFirma { get; set; }
        public string XmlFirmado { get; set; }
        public string XmlRespuesta { get; set; }

        public TbClientes TbClientes { get; set; }
        public TbEmpresa TbEmpresa { get; set; }
        public TbTipoDocumento TipoDocumentoNavigation { get; set; }
        public TbTipoMoneda TipoMonedaNavigation { get; set; }
        public TbTipoPago TipoPagoNavigation { get; set; }
        public TbTipoVenta TipoVentaNavigation { get; set; }
        public IEnumerable<TbDetalleDocumento> TbDetalleDocumento { get; set; }
    }
}
