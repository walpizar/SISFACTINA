using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Data
{
    public partial class TbPermisos
    {
        public int TbRequerimientosIdReq { get; set; }
        public int TbRolesIdRol { get; set; }

        public TbRequerimientos TbRequerimientosIdReqNavigation { get; set; }
        public TbRoles TbRolesIdRolNavigation { get; set; }
    }
}
