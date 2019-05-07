using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Entities.Model
{
    public partial class TbMonedas
    {
        public TbMonedas()
        {
            TbCajaUsuMonedas = new HashSet<TbCajaUsuMonedas>();
        }

        public string IdMoneda { get; set; }
        public string Moneda { get; set; }
        public int IdTipoMoneda { get; set; }
        public bool Estado { get; set; }

        public TbTipoMoneda IdTipoMonedaNavigation { get; set; }
        public ICollection<TbCajaUsuMonedas> TbCajaUsuMonedas { get; set; }
    }
}
