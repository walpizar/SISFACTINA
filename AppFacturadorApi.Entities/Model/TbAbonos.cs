using System;
using System.Collections.Generic;

namespace  AppFacturadorApi.Entities.Model
{
    public partial class TbAbonos
    {
        public int IdAbono { get; set; }
        public int IdDoc { get; set; }
        public int TipoDoc { get; set; }
        public decimal? Monto { get; set; }
        public DateTime FechaUltMod { get; set; }
        public DateTime FechaCrea { get; set; }
        public string UsuarioCrea { get; set; }
        public string UsuarioUltMod { get; set; }
        public bool Estado { get; set; }

        public TbCreditos IdDocNavigation { get; set; }
    }
}
