using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Entities.Model
{
    public partial class TbClientes
    {
        public TbClientes()
        {
            TbDocumento = new HashSet<TbDocumento>();
        }

        public string Id { get; set; }
        public int TipoId { get; set; }
        public int TipoCliente { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public int PrecioAplicar { get; set; }
        public int DescuentoMax { get; set; }
        public int CreditoMax { get; set; }
        public int PlazoCreditoMax { get; set; }
        public string NombreTributario { get; set; }
        public string EncargadoConta { get; set; }
        public string CorreoElectConta { get; set; }
        public int? IdExonercion { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioCrea { get; set; }
        public string UsuarioUltCrea { get; set; }
        public string Contacto { get; set; }

        public TbExoneraciones IdExonercionNavigation { get; set; }
        public TbPersona TbPersona { get; set; }
        public TbTipoClientes TipoClienteNavigation { get; set; }
        public ICollection<TbDocumento> TbDocumento { get; set; }
    }
}
