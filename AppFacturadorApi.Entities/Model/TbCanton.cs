using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Entities.Model
{
    public partial class TbCanton
    {
        public TbCanton()
        {
            TbDistrito = new HashSet<TbDistrito>();
        }

        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Nombre { get; set; }

        public TbProvincia ProvinciaNavigation { get; set; }
        public ICollection<TbDistrito> TbDistrito { get; set; }
    }
}
