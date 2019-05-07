using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Entities.Model
{
    public partial class TbDetalleMovimiento
    {
        public int IdDetalleMov { get; set; }
        public int IdMov { get; set; }
        public int IdIngrediente { get; set; }
        public int Cantidad { get; set; }
        public decimal? Monto { get; set; }

        public TbIngredientes IdIngredienteNavigation { get; set; }
        public TbMovimientos IdMovNavigation { get; set; }
    }
}
