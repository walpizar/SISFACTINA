using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Entities.Model
{
    public partial class TbBarrios
    {
        public TbBarrios()
        {
            TbPersona = new HashSet<TbPersona>();
        }

        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string Barrio { get; set; }
        public string Nombre { get; set; }

        public TbDistrito TbDistrito { get; set; }
        public ICollection<TbPersona> TbPersona { get; set; }
    }
}
