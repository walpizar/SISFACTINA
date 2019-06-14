using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Entities.Model
{
    public partial class TbProveedores
    {
        public TbProveedores()
        {
            TbHorarioProveedor = new HashSet<TbHorarioProveedor>();
            TbProducto = new HashSet<TbProducto>();
        }

        public string Id { get; set; }
        public int TipoId { get; set; }
        public string Descripcion { get; set; }
        public string ContactoProveedor { get; set; }
        public string Fax { get; set; }
        public string NombreTributario { get; set; }
        public string EncargadoConta { get; set; }
        public string CorreoElectConta { get; set; }
        public string CuentaBancaria { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioCrea { get; set; }
        public string UsuarioUltMod { get; set; }

        public TbPersona TbPersona { get; set; }
        public ICollection<TbHorarioProveedor> TbHorarioProveedor { get; set; }
        public ICollection<TbProducto> TbProducto { get; set; }
    }
}
