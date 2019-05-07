using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Data
{
    public partial class TbHorarioProveedor
    {
        public int IdTipo { get; set; }
        public string IdProveedor { get; set; }
        public int IdTipoHorario { get; set; }
        public bool? Lunes { get; set; }
        public bool? Martes { get; set; }
        public bool? Miercoles { get; set; }
        public bool? Jueves { get; set; }
        public bool? Viernes { get; set; }
        public bool? Sabado { get; set; }
        public bool? Domingo { get; set; }

        public TbProveedores Id { get; set; }
    }
}
