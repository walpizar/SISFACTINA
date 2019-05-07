using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Entities.Model
{
    public partial class TbTipoId
    {
        public TbTipoId()
        {
            TbPersona = new HashSet<TbPersona>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<TbPersona> TbPersona { get; set; }
    }
}
