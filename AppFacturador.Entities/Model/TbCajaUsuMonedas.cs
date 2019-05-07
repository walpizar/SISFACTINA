using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Data
{
    public partial class TbCajaUsuMonedas
    {
        public string IdMoneda { get; set; }
        public int IdCajaUsuario { get; set; }
        public int Cantidad { get; set; }
        public int Subtotal { get; set; }

        public TbCajaUsuario IdCajaUsuarioNavigation { get; set; }
        public TbMonedas IdMonedaNavigation { get; set; }
    }
}
