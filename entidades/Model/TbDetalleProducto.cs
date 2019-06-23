using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Entities.Model
{
    public partial class TbDetalleProducto
    {
        public int Id { get; set; }
        public string IdProducto { get; set; }
        public int IdIngrediente { get; set; }
        public float Cantidad { get; set; }

        public TbIngredientes IdIngredienteNavigation { get; set; }
    }
}
