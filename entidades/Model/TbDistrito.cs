using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Entities.Model
{
    public partial class TbDistrito
    {
        public TbDistrito()
        {
            TbBarrios = new HashSet<TbBarrios>();
            TbSucursales = new HashSet<TbSucursales>();
        }

        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string Nombre { get; set; }

        public TbCanton TbCanton { get; set; }
        public ICollection<TbBarrios> TbBarrios { get; set; }
        public ICollection<TbSucursales> TbSucursales { get; set; }
    }
}
