using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Entities.Model
{
    public partial class TbCajaUsuario
    {
        public TbCajaUsuario()
        {
            TbCajaUsuMonedas = new HashSet<TbCajaUsuMonedas>();
            TbMovimientoCajaUsuario = new HashSet<TbMovimientoCajaUsuario>();
        }

        public int Id { get; set; }
        public int IdCaja { get; set; }
        public string IdUser { get; set; }
        public int TipoId { get; set; }
        public int TipoMovCaja { get; set; }
        public DateTime Fecha { get; set; }
        public int? Total { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioCrea { get; set; }
        public string UsuarioUltMod { get; set; }
        public bool Estado { get; set; }

        public TbUsuarios TbUsuarios { get; set; }
        public ICollection<TbCajaUsuMonedas> TbCajaUsuMonedas { get; set; }
        public ICollection<TbMovimientoCajaUsuario> TbMovimientoCajaUsuario { get; set; }
    }
}
