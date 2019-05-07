using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Entities.Model
{
    public partial class TbTipoVenta
    {
        public TbTipoVenta()
        {
            TbDocumento = new HashSet<TbDocumento>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<TbDocumento> TbDocumento { get; set; }
    }
}
