using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Data
{
    public partial class TbDetalleImpresion
    {
        public int Id { get; set; }
        public string NombreEmpresa { get; set; }
        public string TelefonoEmpresa { get; set; }
        public string DireccionEmpresa { get; set; }
        public string MensajeTributacion { get; set; }
        public string MensajeDespedida { get; set; }
        public string LogoEmpresa { get; set; }
    }
}
