using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Data
{
    public partial class TbEmpleado
    {
        public TbEmpleado()
        {
            TbPagos = new HashSet<TbPagos>();
        }

        public string Id { get; set; }
        public int TipoId { get; set; }
        public int IdPuesto { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioCrea { get; set; }
        public string UsuarioUltCrea { get; set; }
        public bool EsContraDefinido { get; set; }
        public string Direccion { get; set; }

        public TbTipoPuesto IdPuestoNavigation { get; set; }
        public TbPersona TbPersona { get; set; }
        public ICollection<TbPagos> TbPagos { get; set; }
    }
}
