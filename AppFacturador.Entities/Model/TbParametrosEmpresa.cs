using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Data
{
    public partial class TbParametrosEmpresa
    {
        public int Id { get; set; }
        public string IdEmpresa { get; set; }
        public int IdTipoEmpresa { get; set; }
        public float UtilidadBase { get; set; }
        public bool ManejaInventario { get; set; }
        public decimal? CambioDolar { get; set; }
        public decimal? DescuentoBase { get; set; }
        public bool? AprobacionDescuento { get; set; }
        public int? PrecioBase { get; set; }
        public bool? FacturacionElectronica { get; set; }
        public bool? ClienteObligatorioFact { get; set; }
        public int? PlazoMaximoCredito { get; set; }
        public int? PlazoMaximoProforma { get; set; }

        public TbEmpresa IdNavigation { get; set; }
    }
}
