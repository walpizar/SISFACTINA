using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Entities.Model
{ 

    public partial class TbExoneraciones
    {
        public TbExoneraciones()
        {
            TbClientes = new HashSet<TbClientes>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Valor { get; set; }

        public ICollection<TbClientes> TbClientes { get; set; }
    }
}
