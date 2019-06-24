using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Entities.Model
{
    public partial class TbMovimientoCajaUsuario
    {
        public int TbCajaUsuarioId { get; set; }
        public int TbMovimientosIdMovimiento { get; set; }

        public TbCajaUsuario TbCajaUsuario { get; set; }
        public TbMovimientos TbMovimientosIdMovimientoNavigation { get; set; }
    }
}
