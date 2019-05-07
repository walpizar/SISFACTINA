using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Data
{
    public partial class TbProvincia
    {
        public TbProvincia()
        {
            TbCanton = new HashSet<TbCanton>();
        }

        public string Cod { get; set; }
        public string Nombre { get; set; }

        public ICollection<TbCanton> TbCanton { get; set; }
    }
}
