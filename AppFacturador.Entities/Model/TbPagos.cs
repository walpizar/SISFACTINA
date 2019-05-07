using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Data
{
    public partial class TbPagos
    {
        public int Id { get; set; }
        public string IdEmpleado { get; set; }
        public int TipoId { get; set; }
        public int CantidadHoras { get; set; }
        public int? CantidadHoraExtra { get; set; }
        public float Total { get; set; }
        public DateTime FechaPago { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioCrea { get; set; }
        public string UsuarioUltMod { get; set; }
        public int IdMovimiento { get; set; }

        public TbMovimientos IdMovimientoNavigation { get; set; }
        public TbEmpleado TbEmpleado { get; set; }
    }
}
