using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Entities.Model
{
    public partial class TbTipoPago
    {
        public TbTipoPago()
        {
            TbDocumento = new HashSet<TbDocumento>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<TbDocumento> TbDocumento { get; set; }
    }
}
