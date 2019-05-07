using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Data
{
    public partial class TbDetalleDocumento
    {
        public int IdTipoDoc { get; set; }
        public int IdDoc { get; set; }
        public string IdProducto { get; set; }
        public int NumLinea { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal MontoTotalDesc { get; set; }
        public decimal MontoTotalImp { get; set; }
        public decimal MontoTotalExo { get; set; }
        public decimal TotalLinea { get; set; }

        public TbDocumento Id { get; set; }
        public TbProducto IdProductoNavigation { get; set; }
    }
}
