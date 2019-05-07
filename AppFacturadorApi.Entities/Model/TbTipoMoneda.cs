using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Entities.Model
{
    public partial class TbTipoMoneda
    {
        public TbTipoMoneda()
        {
           // TbDocumento = new HashSet<TbDocumento>();
            TbMonedas = new HashSet<TbMonedas>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Siglas { get; set; }
        public string Simbolo { get; set; }
        public bool Estado { get; set; }

        public ICollection<TbDocumento> TbDocumento { get; set; }
        public ICollection<TbMonedas> TbMonedas { get; set; }
    }
}
