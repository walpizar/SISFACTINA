using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Data
{
    public partial class TbIngredienteProveedor
    {
        public int TbIngredientesIdIngrediente { get; set; }
        public string TbProveedoresId { get; set; }
        public int TbProveedoresTipoId { get; set; }

        public TbIngredientes TbIngredientesIdIngredienteNavigation { get; set; }
    }
}
